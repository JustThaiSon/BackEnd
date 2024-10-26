using BUS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Product;

namespace DuAnC_5.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		[HttpPost("add-category")]
		public async Task< IActionResult> Create([FromBody]CategoryViewModel request)
		{
            if (ModelState.IsValid)
            {
				var addCategory = await _categoryService.addCategory(request);
				return Ok(addCategory);
            }
			return BadRequest();
		}
		[HttpPut("edit-category/{Id}")]
		public async Task<IActionResult> Update(Guid Id, [FromBody] CategoryViewModel request)
		{
			if (ModelState.IsValid)
			{
				var editCategory = await _categoryService.editCategory(Id, request);
				return Ok(editCategory);
			}
			return BadRequest();
		}
		[HttpDelete("delete-category/{Id}")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			try
			{
				var delete = await _categoryService.deleteCategory(Id);
				return Ok(delete);
			}
			catch (Exception)
			{

				return BadRequest();
			}
		}
		[HttpGet("GetById-category/{Id}")]
		public async Task<IActionResult> GetById(Guid Id)
		{
			try
			{
				var getbyid = await _categoryService.GetById(Id);
				return Ok(getbyid);
			}
			catch (Exception)
			{

				return BadRequest();
			}
		}

		[HttpGet("GetAll-category")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				var getAll = await _categoryService.getAllCategories();
				return Ok(getAll);
			}
			catch (Exception)
			{

				return BadRequest();
			}
		}
	}
}
