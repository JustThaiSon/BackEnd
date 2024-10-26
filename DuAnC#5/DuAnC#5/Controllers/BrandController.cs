using BUS.IService;
using BUS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Product;
using ViewModel.Product.Brand;

namespace DuAnC_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpPost("add-brand")]
        public async Task<IActionResult> Create([FromBody] CreateBrandVM request)
        {
            if (ModelState.IsValid)
            {
                var addBrand = await _brandService.addBrand(request);
                return Ok(addBrand);
            }
            return BadRequest();
        }
        [HttpPut("edit-brand/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] CreateBrandVM request)
        {
            if (ModelState.IsValid)
            {
                var editBrand = await _brandService.editBrand(Id, request);
                return Ok(editBrand);
            }
            return BadRequest();
        }
        [HttpDelete("delete-brand/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var delete = await _brandService.deleteBrand(Id);
                return Ok(delete);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("GetById-Brand/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var getbyid = await _brandService.GetById(Id);
                return Ok(getbyid);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("GetAll-Brand")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var getAll = await _brandService.getAllBrand();
                return Ok(getAll);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
