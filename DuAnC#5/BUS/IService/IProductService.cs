using BUS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Request;

namespace BUS.IService
{
    public interface IProductService
	{
		Task<bool> AddProduct(ProductCreateRequest request);
		Task<bool> UpdateProduct(Guid Id,ProductUpdateRequest request);
		Task<bool> DeleteProduct(Guid Id);
        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
        Task<ApiResult<ProductViewModel>> GetById(Guid Id);
        Task<Guid> AddImage(Guid ProductId, ProductImageCreateRequest request);
        Task<bool> RemoveImage(Guid imageId);
        Task<bool> UpdateImage(Guid imageId, ProductImageUpdateRequest request);
        Task<List<ProductImageViewModel>> GetListImages(Guid productId);
        Task<ProductImageViewModel> GetImageById(Guid imageId);
        Task<ApiResult<bool>> CategoryAssign(Guid id, CategoryAssignRequest request);

    }
}
