using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Orders
{
    public class GetOrdersVM
    {
        public Guid Id { get; set; }
        public string OrderCode { get; set; }
        public StatusOrderEnum Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalPriceSale { get; set; }
        public DateTime DatePayment { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid? VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<OrderDetailsVM> OrderDetails { get; set; }

    }
}
