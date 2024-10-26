using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Product
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public StatusProductEnum Status { get; set; }
        public string Description { get; set; }
        public Guid ManufactureId { get; set; }
        public Guid BrandId { get; set; }
		public string? CreateBy { get; set; }
		public DateTime? CreatedDate { get; set; }

		public string? UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
		public List<Category_Product> Category_Products { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
		public List<CartDetail> CartDetails { get; set; }
		public List<ProductImage> ProductImages { get; set; }
		public Manufacturer Manufacturer { get; set; }
		public Brand Brands { get; set; }
    }
}
