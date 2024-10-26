using BUS.IService;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Product.Manufacturer;

namespace BUS.Service
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly MyDbContext _context;

        public ManufacturerService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> addManufacturer(ManufacturerViewModel request)
        {
            var addManufacturer = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                Country = request.Country,
                CreateBy = request.CreateBy,
                CreatedDate = DateTime.Now,
                Name = request.Name,
            };
            await _context.Manufacturers.AddAsync(addManufacturer);
           await  _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteManufacturer(Guid Id)
        {
            var findmanu = await _context.Manufacturers.FindAsync(Id);
            if (findmanu == null) return false;
            _context.Manufacturers.Remove(findmanu);
             await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> editManufacturer(Guid Id, ManufacturerViewModel request)
        {
            var findmanu = await _context.Manufacturers.FindAsync(Id);
            if (findmanu == null) return false;
            findmanu.Name = request.Name;
            findmanu.UpdateDate = DateTime.Now;
            findmanu.UpdateBy = request.UpdateBy;
            findmanu.Country = request.Country;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GetManufacturerViewModel>> getAllManufacturer()
        {
           var getall = await _context.Manufacturers.ToListAsync();
            return getall.Select(x => new GetManufacturerViewModel
            {
                Id = x.Id,
                Country = x.Country,
                CreateBy = x.CreateBy,
                CreatedDate = x.CreatedDate,
                Name = x.Name,
                UpdateBy = x.UpdateBy,
                UpdateDate = x.UpdateDate
            });
        }

        public async Task<GetManufacturerViewModel> GetById(Guid Id)
        {
            var findById =  await _context.Manufacturers.FindAsync(Id);
            var getManufacturer = new GetManufacturerViewModel
            {
                Id = findById.Id,
                Country = findById.Country,
                CreateBy = findById.CreateBy,
                CreatedDate = findById.CreatedDate,
                Name = findById.Name,
                UpdateBy = findById.UpdateBy,
                UpdateDate = findById.UpdateDate
            };
            return getManufacturer;
        }
    }
}
