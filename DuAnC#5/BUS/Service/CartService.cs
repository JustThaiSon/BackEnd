using BUS.Common;
using BUS.IService;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Cart;
using ViewModel.Product;

namespace BUS.Service
{
    public class CartService : ICartService
    {
        private readonly MyDbContext _Context;

        public CartService(MyDbContext dbContext)
        {
            _Context = dbContext;
        }

        public async Task addToCart(Guid UserId, CartViewModel request)
        {
            var product = await _Context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            if (product.Quantity < request.Quantity)
            {
                throw new Exception("Insufficient product quantity.");
            }

            var cart = await _Context.Carts
                .Include(x => x.CartDetails)
                .FirstOrDefaultAsync(x => x.UserId == UserId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = UserId,
                    Status = DAL.Enum.StatusCartEnum.NotYetPaid,
                    CartDetails = new List<CartDetail>()
                };
                await _Context.Carts.AddAsync(cart);
            }

            var existItem = cart.CartDetails.FirstOrDefault(x => x.ProductId == request.ProductId);
            if (existItem != null)
            {
                existItem.Quantity += request.Quantity;
            }
            else
            {
                var newCartDetail = new CartDetail
                {
                    Id = Guid.NewGuid(),
                    CartId = cart.UserId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    selectedItem = true
                };
                await _Context.CartDetails.AddAsync(newCartDetail);
            }
            await _Context.SaveChangesAsync();

        }

        public async Task<bool> DeleteCart(Guid id)
        {
            var findDelete = await _Context.CartDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (findDelete != null)
            {
                _Context.CartDetails.Remove(findDelete);
                await _Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCartByProductId(Guid id)
        {
            var findDelete = await _Context.CartDetails.FirstOrDefaultAsync(x => x.ProductId == id);
            var cartDetailsToDelete = await _Context.CartDetails
                     .Where(x => x.ProductId == id)
                     .ToListAsync();

            if (cartDetailsToDelete.Any())
            {
                _Context.CartDetails.RemoveRange(cartDetailsToDelete);
                await _Context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<CartVM>> getCartDetails(Guid id)
        {
            var cartDetails = await (from cart in _Context.Carts
                                     join cartDetail in _Context.CartDetails on cart.UserId equals cartDetail.CartId
                                     join product in _Context.Products on cartDetail.ProductId equals product.Id
                                     join productImage in _Context.ProductImages on product.Id equals productImage.ProductId
                                     where cart.UserId == id && productImage.IsDefault == true
                                     select new { cart, cartDetail, product, productImage }).ToListAsync();
            var cartVMs = cartDetails.Select(cd => new CartVM
            {
                Name = cd.product.Name,
                Id = cd.cartDetail.Id,
                CartId = cd.cart.UserId,
                ProductId = cd.product.Id,
                Price = cd.product.Price,
                Quantity = cd.cartDetail.Quantity,
                ImagePath = cd.productImage.ImagePath,
                selectedItem = cd.cartDetail.selectedItem
            });

            return cartVMs;
        }

        public async Task<bool> UpdateCart(Guid id, CartViewModel request)
        {
            var FindCart = await _Context.CartDetails.FindAsync(id);
            if (FindCart == null) return false;
            FindCart.ProductId = request.ProductId;
            FindCart.Quantity = request.Quantity;
            FindCart.selectedItem = request.selectedItem;
            await _Context.SaveChangesAsync();
            return true;
        }

        //public async Task<bool> CheckOutCart() { }
    }
}
