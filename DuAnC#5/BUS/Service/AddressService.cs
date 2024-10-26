using BUS.IService;
using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Address;
using ViewModel.System.Users;

namespace BUS.Service
{
    public class AddressService : IAddressService
    {
        private readonly MyDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AddressService(MyDbContext context, UserManager<AppUser> _userManager)
        {
            _context = context;
            this._userManager = _userManager;
        }

        public async Task<bool> CreateAddress(Guid UserId, AddLocaitonVM request)
        {
            var findUser = await _userManager.FindByIdAsync(UserId.ToString());
            if (findUser == null) return false;
            if (request == null) return false;
            var addAdress = new Address
            {
                Id = Guid.NewGuid(),
                UserId = UserId,
                Description = request.Description,
                DistrictId = request.DistrictId,
                DistrictName = request.DistrictName,
                ProvinceId = request.ProvinceId,
                ProvinceName = request.ProvinceName,
                WardId = request.WardId,
                WardName = request.WardName,
            };
            await _context.Address.AddAsync(addAdress);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteAddress(Guid Id)
        {
            var findDelete = await _context.Address.FindAsync(Id);
            _context.Address.Remove(findDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<AddressViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<AddressViewModel> GetById(Guid Id)
        {

            var find = await _context.Address.FindAsync(Id);
            var getAddress = new AddressViewModel
            {
                Id = find.Id,
                Description = find.Description,
                DistrictId = find.DistrictId,
                DistrictName = find.DistrictName,
                ProvinceId = find.ProvinceId,
                ProvinceName = find.ProvinceName,
                WardId = find.WardId,
                WardName = find.WardName,
            };
            return getAddress;
        }

        public async Task<bool> UpdateAddress(Guid Id, AddLocaitonVM request)
        {
            var findUpdate = await _context.Address.FindAsync(Id);
            if (findUpdate == null) return false;
            findUpdate.Description = request.Description;
            findUpdate.ProvinceName = request.ProvinceName;
            findUpdate.WardName = request.WardName;
            findUpdate.WardId = request.WardId;
            findUpdate.ProvinceId = request.ProvinceId;
            findUpdate.DistrictId = request.DistrictId;
            findUpdate.DistrictName = request.DistrictName;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
