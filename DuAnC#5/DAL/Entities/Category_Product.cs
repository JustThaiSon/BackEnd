using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Category_Product
	{
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid CategoryId { get; set; }
		public Category Categories { get; set; }

	}
}
