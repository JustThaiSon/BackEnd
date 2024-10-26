using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Cart;
using ViewModel.Product;

namespace BUS.IService
{
	public interface ICartService
	{
		Task addToCart(Guid UserId, CartViewModel request);
		Task<IEnumerable<CartVM>> getCartDetails(Guid id);
		Task<bool> DeleteCart(Guid id);
		Task<bool> DeleteCartByProductId(Guid id);
		Task<bool> UpdateCart(Guid id, CartViewModel request);
	}
}
