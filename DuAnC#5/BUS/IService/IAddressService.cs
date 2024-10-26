using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Address;
using ViewModel.System.Roles;
using ViewModel.System.Users;

namespace BUS.IService
{
    public interface IAddressService
    {
        Task<List<AddressViewModel>> GetAll();
        Task<AddressViewModel> GetById(Guid Id);
        Task<bool> CreateAddress(Guid UserId,AddLocaitonVM request);
        Task<bool> UpdateAddress(Guid Id, AddLocaitonVM request);
        Task<bool> DeleteAddress(Guid Id);
    }
}
