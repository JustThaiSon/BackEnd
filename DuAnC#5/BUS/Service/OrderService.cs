using BUS.IService;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Orders;

namespace BUS.Service
{
    public class OrderService : IOrderService
    {
        private readonly MyDbContext _context;

        public OrderService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateOders(OrderViewModel request)
        {
            var addOrder = new Order()
            {
                Id = Guid.NewGuid(),
                CreateBy = request.CreateBy,
                CreatedDate = DateTime.Now,
                DatePayment = DateTime.Now,
                TotalAmount = request.TotalAmount,
                OrderCode = GenerateOrderCode(),
                UserId = request.UserId,
                VoucherId = request.VoucherId,
                Status = request.Status,
                TotalPriceSale = request.TotalPriceSale,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var detail in request.OrderDetails)
            {
                var orderDetail = new OrderDetail
                {
                    Id = Guid.NewGuid(),
                    Price = detail.Price,
                    Quantity = detail.Quantity,
                    CreatedDate = DateTime.Now,
                    ProductId = detail.ProductId,
                    CreateBy = detail.CreateBy,
                    //Status = detail.StatusOrderDetail,
                };
                addOrder.OrderDetails.Add(orderDetail);
                var product = await _context.Products.FindAsync(detail.ProductId);
                if (product != null && product.Quantity >= detail.Quantity)
                {
                    product.Quantity -= detail.Quantity;
                }
                else
                {
                    return false;
                }
            }

            await _context.Orders.AddAsync(addOrder);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var find = await _context.Orders.FindAsync(Id);
            if (find == null) return false;
            _context.Orders.Remove(find);
            await _context.SaveChangesAsync();
            return true;

        }

        public string GenerateOrderCode()
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

        public async Task<List<GetOrdersVM>> GetAllOrders()
        {
            var getall = from od in _context.Orders
                         join oddt in _context.OrderDetails on od.Id equals oddt.OrderId
                         join prd in _context.Products on oddt.ProductId equals prd.Id
                         join us in _context.Users on od.UserId equals us.Id
                         join vc in _context.Vouchers on od.VoucherId equals vc.Id
                         select new { od, oddt, prd, us, vc };

            var data = await getall
                .GroupBy(x => new
                {
                    x.od.Id,
                    x.od.CreateBy,
                    x.od.CreatedDate,
                    x.od.DatePayment,
                    x.od.Status,
                    x.od.TotalAmount,
                    x.od.UpdateBy,
                    x.od.OrderCode,
                    x.od.TotalPriceSale,
                    x.od.UpdateDate,
                    x.od.UserId,
                    x.od.VoucherId
                })
                .Select(g => new GetOrdersVM
                {
                    Id = g.Key.Id,
                    CreateBy = g.Key.CreateBy,
                    CreatedDate = g.Key.CreatedDate,
                    DatePayment = g.Key.DatePayment,
                    Status = g.Key.Status,
                    UserName = g.Select(x => x.us.Name).FirstOrDefault(),
                    VoucherCode = g.Select(x => x.vc.VoucherCode).FirstOrDefault(),
                    TotalAmount = g.Key.TotalAmount,
                    UpdateBy = g.Key.UpdateBy,
                    OrderCode = g.Key.OrderCode,
                    TotalPriceSale = g.Key.TotalPriceSale,
                    UpdateDate = g.Key.UpdateDate,
                    UserId = g.Key.UserId,
                    VoucherId = g.Key.VoucherId,
                    OrderDetails = g.Select(x => new OrderDetailsVM
                    {
                        CreateBy = x.oddt.CreateBy,
                        UpdateBy = x.oddt.UpdateBy,
                        Price = x.oddt.Price,
                        ProductId = x.oddt.ProductId,
                        ProductName = x.prd.Name,
                        Quantity = x.oddt.Quantity
                    }).ToList()
                })
                .ToListAsync();

            return data;
        }

        public async Task<List<GetOrdersVM>> GetAllOrdersPending()
        {
            var getall = from od in _context.Orders
                         join oddt in _context.OrderDetails on od.Id equals oddt.OrderId
                         join prd in _context.Products on oddt.ProductId equals prd.Id
                         join us in _context.Users on od.UserId equals us.Id
                         join vc in _context.Vouchers on od.VoucherId equals vc.Id
                         where od.Status == DAL.Enum.StatusOrderEnum.Pending
                         select new { od, oddt, prd, us, vc };

            var data = await getall
                    .GroupBy(x => new
                    {
                        x.od.Id,
                        x.od.CreateBy,
                        x.od.CreatedDate,
                        x.od.DatePayment,
                        x.od.Status,
                        x.od.TotalAmount,
                        x.od.UpdateBy,
                        x.od.TotalPriceSale,
                        x.od.UpdateDate,
                        x.od.OrderCode,
                        x.od.UserId,
                        x.od.VoucherId
                    })
                    .Select(g => new GetOrdersVM
                    {
                        Id = g.Key.Id,
                        CreateBy = g.Key.CreateBy,
                        CreatedDate = g.Key.CreatedDate,
                        DatePayment = g.Key.DatePayment,
                        Status = g.Key.Status,
                        OrderCode = g.Key.OrderCode,
                        UserName = g.Select(x => x.us.Name).FirstOrDefault(),
                        VoucherCode = g.Select(x => x.vc.VoucherCode).FirstOrDefault(),
                        TotalAmount = g.Key.TotalAmount,
                        UpdateBy = g.Key.UpdateBy,
                        TotalPriceSale = g.Key.TotalPriceSale,
                        UpdateDate = g.Key.UpdateDate,
                        UserId = g.Key.UserId,
                        VoucherId = g.Key.VoucherId,
                        OrderDetails = g.Select(x => new OrderDetailsVM
                        {
                            CreateBy = x.oddt.CreateBy,
                            UpdateBy = x.oddt.UpdateBy,
                            Price = x.oddt.Price,
                            ProductId = x.oddt.ProductId,
                            ProductName = x.prd.Name,
                            Quantity = x.oddt.Quantity
                        }).ToList()
                    })
                    .ToListAsync();

            return data;
        }

        public async Task<GetOrdersVM> GetByIdOrders(Guid Id)
        {
            var getall = from od in _context.Orders
                         join oddt in _context.OrderDetails on od.Id equals oddt.OrderId
                         join prd in _context.Products on oddt.ProductId equals prd.Id
                         join us in _context.Users on od.UserId equals us.Id
                         join vc in _context.Vouchers on od.VoucherId equals vc.Id
                         where od.Id == Id
                         select new { od, oddt, prd, us, vc };
            var data = await getall
              .GroupBy(x => new
              {
                  x.od.Id,
                  x.od.CreateBy,
                  x.od.CreatedDate,
                  x.od.DatePayment,
                  x.od.Status,
                  x.od.TotalAmount,
                  x.od.UpdateBy,
                  x.od.TotalPriceSale,
                  x.od.OrderCode,
                  x.od.UpdateDate,
                  x.od.UserId,
                  x.od.VoucherId
              })
              .Select(g => new GetOrdersVM
              {
                  Id = g.Key.Id,
                  CreateBy = g.Key.CreateBy,
                  CreatedDate = g.Key.CreatedDate,
                  DatePayment = g.Key.DatePayment,
                  Status = g.Key.Status,
                  OrderCode = g.Key.OrderCode,
                  UserName = g.Select(x => x.us.Name).FirstOrDefault(),
                  VoucherCode = g.Select(x => x.vc.VoucherCode).FirstOrDefault(),
                  TotalAmount = g.Key.TotalAmount,
                  UpdateBy = g.Key.UpdateBy,
                  TotalPriceSale = g.Key.TotalPriceSale,
                  UpdateDate = g.Key.UpdateDate,
                  UserId = g.Key.UserId,
                  VoucherId = g.Key.VoucherId,
                  OrderDetails = g.Select(x => new OrderDetailsVM
                  {
                      CreateBy = x.oddt.CreateBy,
                      UpdateBy = x.oddt.UpdateBy,
                      Price = x.oddt.Price,
                      ProductId = x.oddt.ProductId,
                      ProductName = x.prd.Name,
                      Quantity = x.oddt.Quantity
                  }).ToList()
              })
              .FirstOrDefaultAsync();

            return data;
        }

        public async Task<bool> updateOrder(Guid Id, OrderViewModel request)
        {
            var findId = await _context.Orders.FindAsync(Id);
            if (findId == null) return false;
            findId.UpdateDate = DateTime.Now;
            findId.UpdateBy = request.UpdateBy;
            findId.TotalAmount = request.TotalAmount;
            findId.TotalPriceSale = request.TotalPriceSale;
            findId.Status = request.Status;
            foreach (var item in findId.OrderDetails)
            {
                var updatedDetail = request.OrderDetails.FirstOrDefault(d => d.Id == item.Id);
                if (updatedDetail != null)
                {
                    item.Quantity = updatedDetail.Quantity;
                    item.Price = updatedDetail.Price;
                    item.ProductId = updatedDetail.ProductId;
                }
            }
            foreach (var newDetail in request.OrderDetails.Where(d => !findId.OrderDetails.Any(od => od.Id == d.Id)))
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = newDetail.ProductId,
                    Quantity = newDetail.Quantity,
                    Price = newDetail.Price,
                };
                findId.OrderDetails.Add(orderDetail);
            }
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateSatus(Guid Id, UpdateStatusOrder request)
        {
            var find = await _context.Orders.FindAsync(Id);
            if (find == null) return false;
            if (request.Status == DAL.Enum.StatusOrderEnum.Cancelled)
            {
                foreach (var product in find.OrderDetails)
                {
                    var productEntity = await _context.Products.FindAsync(product.ProductId);
                    if (productEntity != null)
                    {
                        productEntity.Quantity += product.Quantity;
                    }
                }
            }
            find.Status = request.Status;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
