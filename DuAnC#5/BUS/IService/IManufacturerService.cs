using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Product.Manufacturer;

namespace BUS.IService
{
    public interface IManufacturerService
    {
        Task<bool> addManufacturer(ManufacturerViewModel request);
        Task<bool> editManufacturer(Guid Id, ManufacturerViewModel request);
        Task<bool> deleteManufacturer(Guid Id);
        Task<IEnumerable<GetManufacturerViewModel>> getAllManufacturer();
        Task<GetManufacturerViewModel> GetById(Guid Id);
    }
}
