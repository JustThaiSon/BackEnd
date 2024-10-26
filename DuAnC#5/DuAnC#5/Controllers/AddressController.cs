using BUS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Address;

namespace DuAnC_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _addressService.DeleteAddress(Id);
            if (!result) return BadRequest();
            return Ok();

        }
        [HttpPost("Create-address")]
        public async Task<IActionResult> Create(Guid UserId,AddLocaitonVM request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _addressService.CreateAddress(UserId, request);
            if (!result) return BadRequest();
            return Ok(result);

        }
        [HttpPut("Update-address/{Id}")]
        public async Task<IActionResult> Update(Guid Id,AddLocaitonVM request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _addressService.UpdateAddress(Id, request);
            if (!result) return BadRequest();
            return Ok(result);

        }
        [HttpGet("get-by-id/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _addressService.GetById(Id);
            return Ok(result);

        }

    }
}
