using BUS.IService;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Product;
using ViewModel.Product.Brand;

namespace BUS.Service
{
    public class BrandService : IBrandService
    {
        private readonly MyDbContext _context;

        public BrandService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> addBrand(CreateBrandVM request)
        {
            try
            {
                var addBrand = new Brand()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    CreateBy = request.CreateBy,
                    CreatedDate = DateTime.Now,
                    Description = request.Description,
                    Status = request.Status,
                };
                await _context.Brands.AddAsync(addBrand);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> deleteBrand(Guid Id)
        {
            var findBrand = await _context.Brands.FindAsync(Id);
            if (findBrand == null) return false;
            _context.Brands.Remove(findBrand);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> editBrand(Guid Id, CreateBrandVM request)
        {
            var findEdit = await _context.Brands.FindAsync(Id);
            if (findEdit == null)
            {
                return false;
            }
            findEdit.Id = Id;
            findEdit.Name = request.Name;
            findEdit.Status = request.Status;
            findEdit.UpdateBy = request.UpdateBy;
            findEdit.UpdateDate = DateTime.Now;
            findEdit.Description = request.Description;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BrandViewModel>> getAllBrand()
        {
            return await _context.Brands.Select(brd => new BrandViewModel
            {
                Id = brd.Id,
                Name = brd.Name,
                CreateBy = brd.CreateBy,
                CreatedDate = brd.CreatedDate,
                Description = brd.Description,
                Status = brd.Status,
                UpdateBy = brd.UpdateBy,
                UpdateDate = brd.UpdateDate,
            }).ToListAsync();
        }

        public async Task<BrandViewModel> GetById(Guid Id)
        {
            var getbyId = await _context.Brands.FindAsync(Id);
            if (getbyId == null)
            {
                throw new Exception("brand not found");
            }
            var brandbyId = new BrandViewModel
            {
                Id = getbyId.Id,
                CreateBy = getbyId.CreateBy,
                CreatedDate = getbyId.CreatedDate,
                Description = getbyId.Description,
                Name = getbyId.Name,
                Status = getbyId.Status,
                UpdateBy = getbyId.UpdateBy,
                UpdateDate = getbyId.UpdateDate,
            };
            return brandbyId;
        }
    }
}
