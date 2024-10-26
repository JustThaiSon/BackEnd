using Azure.Core;
using BUS.Common;
using BUS.IService;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Catalog;
using ViewModel.Request;

namespace DuAnC_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetProductPagingRequest request)
        {
            var product = await _productService.GetAllPaging(request);
            return Ok(product);
        }
        [HttpPost("Create-product")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var create = await _productService.AddProduct(request);
            return Ok(create);
        }
        [HttpPost("add-image/{productId}")]
        public async Task<IActionResult> createImage(Guid productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productService.AddImage(productId, request);

            if (imageId == null)
            {
                return BadRequest();
            }

            var image = await _productService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        [HttpGet("get-image/{id}")]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            var image = await _productService.GetImageById(id);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }
        [HttpGet("GetAllImage/{productId}")]
        public async Task<IActionResult> GetAllImage(Guid productId)
        {
            var getall = await _productService.GetListImages(productId);
            return Ok(getall);
        }
        [HttpDelete("Delete-Product/{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var delete = await _productService.DeleteProduct(productId);
            return Ok(delete);
        }

        [HttpGet("Get-Product-ById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var image = await _productService.GetById(id);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }
        [HttpPut("update-product/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var create = await _productService.UpdateProduct(Id, request);
            return Ok(create);
        }
        [HttpDelete("delete-image/{Id}")]
        public async Task<IActionResult> RemoveImage(Guid Id)
        {
            var delete = await _productService.RemoveImage(Id);
            return Ok(delete);
        }
        [HttpPut("update-Image/{Id}")]
        public async Task<IActionResult> UpdateImage(Guid Id, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var create = await _productService.UpdateImage(Id, request);
            return Ok(create);
        }
        [HttpGet("Get-Product-Image-ById/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var image = await _productService.GetImageById(id);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }
        [HttpPut("AssignCategory/{Id}")]
        public async Task<IActionResult> AssignCategory(Guid Id,[FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var result = await _productService.CategoryAssign(Id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
