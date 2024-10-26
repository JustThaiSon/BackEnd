using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class OrderDetail
	{
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public Order Orders { get; set; }   
        public Product Products { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
		public string? CreateBy { get; set; }
		public DateTime? CreatedDate { get; set; }

		public string? UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
		//public StatusOrderDetailsEnum Status { get; set; }
    }
}
