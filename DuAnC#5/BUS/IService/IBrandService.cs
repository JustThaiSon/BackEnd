using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Product;
using ViewModel.Product.Brand;

namespace BUS.IService
{
    public interface IBrandService
    {
        Task<bool> addBrand(CreateBrandVM request);
        Task<bool> editBrand(Guid Id, CreateBrandVM request);
        Task<bool> deleteBrand(Guid Id);
        Task<IEnumerable<BrandViewModel>> getAllBrand();
        Task<BrandViewModel> GetById(Guid Id);
    }
}
