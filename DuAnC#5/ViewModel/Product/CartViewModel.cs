using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Product
{
	public class CartViewModel
	{
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }

		public bool selectedItem { get; set; }

    }
}
