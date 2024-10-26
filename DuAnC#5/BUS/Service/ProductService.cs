using BUS.Common;
using BUS.IService;
using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Product;
using ViewModel.Request;
using ViewModel.System.Users;

namespace BUS.Service
{
    public class ProductService : IProductService
    {
        private readonly MyDbContext _context;
        private readonly IStorageService _storageService;

        public ProductService(MyDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<Guid> AddImage(Guid ProductId, ProductImageCreateRequest request)
        {
            if (request == null || request.ImageFile == null)
                throw new ArgumentException("Image file is required");

            var productImage = new ProductImage()
            {
                ProductId = ProductId,
                Caption = request.Caption ?? "Product Image",
                CreateBy = request.CreateBy,
                CreatedDate = DateTime.Now,
                IsDefault = request.IsDefault,
                SortOrder = request.SortOrder
            };

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            if (request.IsDefault == true)
            {
                var updateIsDefault = await _context.ProductImages.FirstOrDefaultAsync(x => x.IsDefault == true && x.ProductId == ProductId);
                if (updateIsDefault != null)
                {
                    updateIsDefault.IsDefault = false;
                }
            }

            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();

            return productImage.Id;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<bool> AddProduct(ProductCreateRequest request)
        {
            var product = new Product()
            {
                BrandId = request.BrandId,
                CreateBy = request.CreateBy,
                Price = request.Price,
                Description = request.Description,
                ManufactureId = request.ManufactureId,
                Name = request.Name,
                Status = request.Status,
                Id = Guid.NewGuid(),
                Quantity = request.Quantity,
                CreatedDate = DateTime.Now
            };
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        CreateBy= request.CreateBy,
                        CreatedDate= DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        Id = Guid.NewGuid(),
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(Guid Id)
        {
            var product = await _context.Products.FindAsync(Id);
            if (product == null) return false;
            var images = _context.ProductImages.Where(x => x.ProductId == Id);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join b in _context.Brands on p.BrandId equals b.Id
                        join m in _context.Manufacturers on p.ManufactureId equals m.Id
                        join pt in _context.ProductImages on p.Id equals pt.ProductId into ppic
                        from pt in ppic.DefaultIfEmpty()
                        join cp in _context.Category_Products on p.Id equals cp.ProductId into ppi
                        from cp in ppi.DefaultIfEmpty()
                        join c in _context.Categories on cp.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        where pt.IsDefault == true || p.ProductImages == null
                        select new { p, m, pt, cp, c, b };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.Name.Contains(request.Keyword));
            }
            if (request.CategoryId != null && request.CategoryId != Guid.Empty)
            {
                query = query.Where(x => x.cp != null && x.cp.CategoryId == request.CategoryId);
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                  .Take(request.PageSize)
                                  .Select(x => new ProductViewModel()
                                  {
                                      Id = x.p.Id,
                                      NameBrand = x.b.Name,
                                      CreateBy = x.p.CreateBy,
                                      CreatedDate = x.p.CreatedDate,
                                      Description = x.p.Description,
                                      Name = x.p.Name,
                                      NameManufacturer = x.m.Name,
                                      Price = x.p.Price,
                                      Quantity = x.p.Quantity,
                                      Status = x.p.Status,
                                      UpdateBy = x.p.UpdateBy,
                                      UpdateDate = x.p.UpdateDate,
                                      ThumbnailImage = x.pt.ImagePath
                                  })
                                  .Distinct()
                                  .ToListAsync();

            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return pageResult;
        }

        public async Task<ApiResult<ProductViewModel>> GetById(Guid Id)
        {
            var product = await _context.Products.FindAsync(Id);
            var categories = await (from c in _context.Categories
                                    join pc in _context.Category_Products on c.Id equals pc.CategoryId
                                    join p in _context.Products on pc.ProductId equals p.Id
                                    where pc.ProductId == Id
                                    select c.Name
                                    ).ToListAsync();
            var brand = await (from b in _context.Brands
                               join p in _context.Products on b.Id equals p.BrandId
                               where p.Id == Id
                               select b.Name).FirstOrDefaultAsync();

            var manufacturer = await (from m in _context.Manufacturers
                                      join p in _context.Products on m.Id equals p.ManufactureId
                                      where p.Id == Id
                                      select m.Name).FirstOrDefaultAsync();

            var image = await _context.ProductImages.Where(x => x.ProductId == Id && x.IsDefault == true).FirstOrDefaultAsync();
            var productVM = new ProductViewModel()
            {
                Id = product.Id,
                CreatedDate = product.CreatedDate,
                Name = product.Name,
                Categories = categories,
                CreateBy = product.CreateBy,
                Description = product.Description,
                NameBrand = brand,
                NameManufacturer = manufacturer,
                BrandId = product.BrandId,
                ManufactureId = product.ManufactureId,
                Price = product.Price,
                Quantity = product.Quantity,
                Status = product.Status,
                UpdateBy = product.UpdateBy,
                UpdateDate = product.UpdateDate,
                ThumbnailImage = image != null ? image.ImagePath : "no-image.jpg"
            };
            return new ApiSuccessResult<ProductViewModel>(productVM);
        }

        public async Task<ProductImageViewModel> GetImageById(Guid imageId)
        {
            var image = await _context.ProductImages.FindAsync(imageId);
            if (image == null) throw new KeyNotFoundException($"Image with ID {imageId} was not found.");
            var viewModel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                CreateBy = image.CreateBy,
                CreatedDate = image.CreatedDate,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                SortOrder = image.SortOrder,
                ProductId = image.ProductId,
                UpdateBy = image.UpdateBy,
                UpdateDate = image.UpdateDate,
            };
            return viewModel;
        }

        public async Task<List<ProductImageViewModel>> GetListImages(Guid productId)
        {
            return await _context.ProductImages.Where(x => x.ProductId == productId).Select(x => new ProductImageViewModel()
            {
                ProductId = x.ProductId,
                UpdateDate = x.UpdateDate,
                UpdateBy = x.UpdateBy,
                Caption = x.Caption,
                CreateBy = x.CreateBy,
                CreatedDate = x.CreatedDate,
                FileSize = x.FileSize,
                Id = x.Id,
                ImagePath = x.ImagePath,
                SortOrder = x.SortOrder,
                IsDefault = x.IsDefault,
            }).ToListAsync();
        }

        public async Task<bool> RemoveImage(Guid imageId)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null) return false;
            _context.ProductImages.Remove(productImage);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateImage(Guid imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                return false;
            productImage.Caption = request.Caption;
            productImage.UpdateBy = request.UpdateBy;
            productImage.UpdateDate = DateTime.Now;
            productImage.SortOrder = request.SortOrder;
            productImage.IsDefault = request.IsDefault;

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            if (request.IsDefault == true)
            {
                var findIsDefault = await _context.ProductImages.FirstOrDefaultAsync(x => x.IsDefault == true && x.ProductId == request.ProductId);
                if (findIsDefault != null)
                {
                    findIsDefault.IsDefault = false;
                }
            }
            _context.ProductImages.Update(productImage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProduct(Guid Id, ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(Id);
            if (product == null) return false;

            product.Name = request.Name;
            product.ManufactureId = request.ManufactureId;
            product.BrandId = request.BrandId;
            product.UpdateBy = request.UpdateBy;
            product.UpdateDate = DateTime.Now;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Quantity = request.Quantity;
            product.Status = request.Status;
            if (request.ThumbnailImage != null)
            {
                var thumb = await _context.ProductImages.FirstOrDefaultAsync(x => x.IsDefault == true && x.ProductId == Id);
                if (thumb != null)
                {
                    thumb.FileSize = request.ThumbnailImage.Length;
                    thumb.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumb);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<bool>> CategoryAssign(Guid id, CategoryAssignRequest request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} was not found.");
            }
            foreach (var category in request.Categories)
            {
                var productCategory = await _context.Category_Products.FirstOrDefaultAsync(x => x.CategoryId == Guid.Parse(category.Id) && x.ProductId == id);
                if (productCategory != null && category.Selected == false)
                {
                    _context.Category_Products.Remove(productCategory);
                }
                else if (productCategory == null && category.Selected)
                {
                    await _context.Category_Products.AddAsync(new Category_Product()
                    {
                        CategoryId = Guid.Parse(category.Id),
                        ProductId = id,
                    });
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}
