using BUS.IService;
using BUS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Product;
using ViewModel.Product.Voucher;

namespace DuAnC_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;

        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        [HttpPost("add-Voucher")]
        public async Task<IActionResult> Create([FromBody] VoucherViewModel request)
        {
            if (ModelState.IsValid)
            {
                var addCategory = await _voucherService.addVoucher(request);
                return Ok(addCategory);
            }
            return BadRequest();
        }
        [HttpPut("edit-voucher/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] VoucherViewModel request)
        {
            if (ModelState.IsValid)
            {
                var editCategory = await _voucherService.editVoucher(Id, request);
                return Ok(editCategory);
            }
            return BadRequest();
        }
        [HttpDelete("delete-voucher/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var delete = await _voucherService.deleteVoucher(Id);
                return Ok(delete);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("GetById-voucher/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var getbyid = await _voucherService.GetById(Id);
                return Ok(getbyid);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("GetAll-voucher")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var getAll = await _voucherService.getAllVoucher();
                //await _voucherService.UpdateVoucherStatusAuTo();
                return Ok(getAll);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
