using BUS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnC_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private readonly ISlideService _slideService;

        public SlideController(ISlideService _slideService)
        {
            this._slideService = _slideService;
        }
        [HttpGet("GetSlide/{Id}")]
        public async Task<IActionResult> GetSildeByProduct(Guid Id)
        {
            var getimg = await _slideService.GetSlideByProduct(Id);

            return Ok(getimg);
        }
    }
}
