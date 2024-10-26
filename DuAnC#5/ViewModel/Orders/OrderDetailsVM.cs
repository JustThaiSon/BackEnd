using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Orders
{
    public class OrderDetailsVM
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid? OrderId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        //public StatusOrderDetailsEnum StatusOrderDetail { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
    }
}
