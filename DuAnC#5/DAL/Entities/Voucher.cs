using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Voucher
	{
		public Guid Id { get; set; }

		public string Name { get; set; }
		public string VoucherCode { get; set; }
		public string Description { get; set; }

		public string? CreateBy { get; set; }
		public DateTime? CreatedDate { get; set; }

		public string? UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public decimal MinimumValue { get; set; }
		public StatusVoucherEnum Status { get; set; }
        public int Quantity { get; set; }
        public decimal PercentSale { get; set; }

		public List<Order> Orders { get; set; }

	}
}
