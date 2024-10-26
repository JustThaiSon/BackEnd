using BUS.IService;
using DAL.Data;
using DAL.Entities;
using DAL.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Product.Voucher;

namespace BUS.Service
{
    public class VoucherService : IVoucherService
    {
        private readonly MyDbContext _context;

        public VoucherService(MyDbContext context)
        {
            _context = context;
        }

        public string GenerateVoucherCode()
        {
            long timestamp = DateTime.UtcNow.Ticks;
            int random = new Random().Next(1000, 9999); 

            long truncatedTimestamp = timestamp % 1000000;

            string base36 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var buffer = new StringBuilder();
            while (truncatedTimestamp > 0)
            {
                buffer.Insert(0, base36[(int)(truncatedTimestamp % 36)]);
                truncatedTimestamp /= 36;
            }
            string result = buffer.ToString() + random.ToString();
            if (result.Length > 8)
            {
                result = result.Substring(0, 8);
            }
            else if (result.Length < 8)
            {
                result = result.PadRight(8, '0');
            }

            return result;
        }
        public async Task<bool> addVoucher(VoucherViewModel request)
        {
            var addVoucher = new Voucher
            {
                Id = Guid.NewGuid(),
                CreateBy = request.CreateBy,
                CreatedDate = DateTime.Now,
                Description = request.Description,
                EndDate = DateTime.Now,
                MinimumValue = request.MinimumValue,
                Name = request.Name,
                PercentSale = request.PercentSale,
                Quantity = request.Quantity,
                StartDate = DateTime.Now,
                Status = AddVoucherStatus(request),
                VoucherCode = GenerateVoucherCode(),
            };
            await _context.Vouchers.AddAsync(addVoucher);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteVoucher(Guid Id)
        {
            var FindVoucher = await _context.Vouchers.FindAsync(Id);
            if (FindVoucher == null) return false;
          
             _context.Vouchers.Remove(FindVoucher);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> editVoucher(Guid Id, VoucherViewModel request)
        {
            var FindVoucher = await _context.Vouchers.FindAsync(Id);
            if (FindVoucher == null) return false;
            FindVoucher.UpdateDate = DateTime.Now;
            FindVoucher.UpdateBy = request.UpdateBy;
            FindVoucher.VoucherCode = request.VoucherCode;
            FindVoucher.Description = request.Description;
            if (request.Status == StatusVoucherEnum.Disabled)
            {
                FindVoucher.Status = StatusVoucherEnum.Disabled;
            }
            FindVoucher.EndDate = request.EndDate;
            FindVoucher.StartDate = request.StartDate;
            FindVoucher.Name = request.Name;
            FindVoucher.MinimumValue = request.MinimumValue;
            FindVoucher.Quantity = request.Quantity;
            FindVoucher.PercentSale = request.PercentSale;
            await _context.SaveChangesAsync();
            return true;
        }

        public StatusVoucherEnum AddVoucherStatus(VoucherViewModel voucher)
        {
            DateTime now = DateTime.UtcNow;

            if (voucher.Status == StatusVoucherEnum.Disabled)
            {
                return StatusVoucherEnum.Disabled;
            }
            else if (now < voucher.StartDate)
            {
                return StatusVoucherEnum.Pending; // Chưa đến ngày bắt đầu
            }
            else if (now > voucher.EndDate)
            {
                return StatusVoucherEnum.Expired; // Đã qua ngày kết thúc
            }
            else if (now >= voucher.StartDate && now <= voucher.EndDate)
            {
                return StatusVoucherEnum.Active; // Đang trong thời gian sử dụng
            }
            else
            {
                return StatusVoucherEnum.Pending; // Trường hợp khác (mặc định chưa đến ngày bắt đầu)
            }
        }

        public async Task UpdateVoucherStatusAuTo()
        {
            var vouchers = await _context.Vouchers.ToListAsync();

            foreach (var voucher in vouchers)
            {
                DateTime now = DateTime.UtcNow;


                if (voucher.Status == StatusVoucherEnum.Disabled)
                {
                    voucher.Status = StatusVoucherEnum.Disabled;
                }
                else if (now < voucher.StartDate)
                {
                    voucher.Status = StatusVoucherEnum.Pending; // Chưa đến ngày bắt đầu
                }
                else if (now > voucher.EndDate)
                {
                    voucher.Status = StatusVoucherEnum.Expired; // Đã qua ngày kết thúc
                }
                else if (now >= voucher.StartDate && now <= voucher.EndDate)
                {
                    voucher.Status = StatusVoucherEnum.Active; // Đang trong thời gian sử dụng
                }
                else
                {
                    voucher.Status = StatusVoucherEnum.Pending; // Trường hợp khác (mặc định chưa đến ngày bắt đầu)
                }
            }

            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<GetVoucherViewModel>> getAllVoucher()
        {
            var FindVoucher = await _context.Vouchers.ToListAsync();
            return FindVoucher.Select(x => new GetVoucherViewModel()
            {
                Id = x.Id,
                EndDate = x.EndDate,
                Description = x.Description,
                CreateBy = x.CreateBy,
                CreatedDate = x.CreatedDate,
                MinimumValue = x.MinimumValue,
                Name = x.Name,
                PercentSale = x.PercentSale,
                Quantity = x.Quantity,
                StartDate = x.StartDate,
                Status = x.Status,
                UpdateBy = x.UpdateBy,
                UpdateDate = x.UpdateDate,
                VoucherCode = x.VoucherCode
                
            });

        }

        public async Task<GetVoucherViewModel> GetById(Guid Id)
        {
            var FindVoucher = await _context.Vouchers.FindAsync(Id);
            var getbyid = new GetVoucherViewModel
            {
                Id = FindVoucher.Id,
                EndDate = FindVoucher.EndDate,
                Description = FindVoucher.Description,
                CreateBy = FindVoucher.CreateBy,
                CreatedDate = FindVoucher.CreatedDate,
                MinimumValue = FindVoucher.MinimumValue,
                Name = FindVoucher.Name,
                PercentSale = FindVoucher.PercentSale,
                Quantity = FindVoucher.Quantity,
                StartDate = FindVoucher.StartDate,
                Status = FindVoucher.Status,
                UpdateBy = FindVoucher.UpdateBy,
                UpdateDate = FindVoucher.UpdateDate,
                VoucherCode = FindVoucher.VoucherCode
            };
            return getbyid;
        }
    }
}
