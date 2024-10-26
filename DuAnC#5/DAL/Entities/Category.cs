using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Category
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public string? CreateBy { get; set; }
		public DateTime? CreatedDate { get; set; }

		public string? UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

		public List<Category_Product> Category_Products { get; set;}
    }
}
