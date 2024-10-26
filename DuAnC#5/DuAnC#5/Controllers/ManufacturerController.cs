using BUS.IService;
using BUS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Product.Manufacturer;
using ViewModel.Product.Voucher;

namespace DuAnC_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpPost("add-manufacturer")]
        public async Task<IActionResult> Create([FromBody] ManufacturerViewModel request)
        {
            if (ModelState.IsValid)
            {
                var addManu = await _manufacturerService.addManufacturer(request);
                return Ok(addManu);
            }
            return BadRequest();
        }
        [HttpPut("edit-manufacturer/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] ManufacturerViewModel request)
        {
            if (ModelState.IsValid)
            {
                var edit = await _manufacturerService.editManufacturer(Id, request);
                return Ok(edit);
            }
            return BadRequest();
        }
        [HttpDelete("delete-manufacturer/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var delete = await _manufacturerService.deleteManufacturer(Id);
                return Ok(delete);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("GetById-manufacturer/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var getbyid = await _manufacturerService.GetById(Id);
                return Ok(getbyid);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("GetAll-manufacturer")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var getAll = await _manufacturerService.getAllManufacturer();
                return Ok(getAll);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
