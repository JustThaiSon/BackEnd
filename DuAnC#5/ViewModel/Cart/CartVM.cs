using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Cart
{
    public class CartVM
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }

        public bool selectedItem { get; set; }
        public decimal TotalPrice => Quantity * Price;
    }
}
