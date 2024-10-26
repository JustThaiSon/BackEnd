using BUS.IService;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Product;

namespace DuAnC_5.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ICartService _cartService;

		public CartController(ICartService cartService)
		{
			_cartService = cartService;
		}
		[HttpPost("Add-Cart/{userId}")]
		public async Task<IActionResult> AddToCart(Guid userId,[FromBody] CartViewModel request)
		{
			if (request == null || request.ProductId == Guid.Empty || request.Quantity <= 0)
			{
				return BadRequest("Invalid cart item.");
			}
			try
			{
				await _cartService.addToCart(userId, request);
				return Ok(new { Message = "Product added to cart and stock updated successfully." });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpGet("GetCart/{Id}")]
		public async Task<IActionResult> GetCartItems(Guid Id)
		{
			var cartItems = await _cartService.getCartDetails(Id);
            if (cartItems == null)
            {
				return BadRequest();
            }
            return Ok(cartItems);
		}
		[HttpDelete("DeleteCart/{Id}")]
		public async Task< IActionResult> DeleteCart(Guid Id)
		{
			var delete =  await _cartService.DeleteCart(Id);
			return Ok(delete);
		}
        [HttpDelete("DeleteCartByProductId/{Id}")]
        public async Task<IActionResult> DeleteCartByProduct(Guid Id)
        {
            var delete = await _cartService.DeleteCartByProductId(Id);
            return Ok(delete);
        }
        [HttpPut("UpdateCart/{Id}")]
        public async Task<IActionResult> UpdateCart(Guid Id,CartViewModel request)
        {
            var cartItems = await _cartService.UpdateCart(Id, request);
            if (cartItems == null)
            {
                return BadRequest();
            }
            return Ok(cartItems);
        }
    }
}
