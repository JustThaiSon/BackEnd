using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Orders;

namespace BUS.IService
{
    public interface IOrderService
    {
        Task<bool> CreateOders(OrderViewModel request);
        Task<List<GetOrdersVM>> GetAllOrders();
        Task<List<GetOrdersVM>> GetAllOrdersPending();
        Task<GetOrdersVM> GetByIdOrders(Guid Id);
        Task<bool> UpdateSatus(Guid Id, UpdateStatusOrder request);
        Task<bool> Delete(Guid Id);
        Task<bool> updateOrder(Guid Id, OrderViewModel request);

    }
}
