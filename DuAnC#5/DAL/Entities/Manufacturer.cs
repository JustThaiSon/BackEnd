using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Manufacturer
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
		public string? CreateBy { get; set; }
		public DateTime? CreatedDate { get; set; }

		public string? UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
		public List<Product> Products { get; set; }
    }
}
