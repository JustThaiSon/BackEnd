using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class CartDetail
	{
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CartId { get; set; }
        public Cart Carts { get; set; }
        public int Quantity { get; set; }
        public bool selectedItem { get; set; }

    }
}
