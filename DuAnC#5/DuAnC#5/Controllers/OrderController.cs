using BUS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Orders;

namespace DuAnC_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create-Order")]
        public async Task<IActionResult> create(OrderViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addOrder = await _orderService.CreateOders(request);
            return Ok(addOrder);
        }
        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAllOrders()
        {
            var getAll = await _orderService.GetAllOrders();
            return Ok(getAll);
        }

        [HttpGet("GetAllOrderPending")]
        public async Task<IActionResult> GetAllOrderPending()
        {
            var getAll = await _orderService.GetAllOrdersPending();
            return Ok(getAll);
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var getAll = await _orderService.GetByIdOrders(Id);
            return Ok(getAll);
        }
        [HttpDelete("DeleteOrder/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var delete = await _orderService.Delete(Id);
            return Ok(delete);
        }

        [HttpPut("updateStatus/{Id}")]
        public async Task<IActionResult> updateStatus(Guid Id,[FromBody] UpdateStatusOrder request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getAll = await _orderService.UpdateSatus(Id, request);
            return Ok(getAll);
        }
        [HttpPut("updateOrder/{Id}")]
        public async Task<IActionResult> updateOrder(Guid Id, [FromBody] OrderViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getAll = await _orderService.updateOrder(Id, request);
            return Ok(getAll);
        }
    }
}
