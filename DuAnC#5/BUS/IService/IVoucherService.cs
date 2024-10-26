using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Product.Brand;
using ViewModel.Product.Voucher;

namespace BUS.IService
{
    public interface IVoucherService
    {
        Task<bool> addVoucher(VoucherViewModel request);
        Task<bool> editVoucher(Guid Id, VoucherViewModel request);
        Task<bool> deleteVoucher(Guid Id);
        Task<IEnumerable<GetVoucherViewModel>> getAllVoucher();
        Task<GetVoucherViewModel> GetById(Guid Id);
        Task UpdateVoucherStatusAuTo();
    }
}
