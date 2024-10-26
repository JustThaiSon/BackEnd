using BUS.Systems.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.System.Roles;

namespace DuAnC_5.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    [Authorize]
    public class RoleController : ControllerBase
	{
		private readonly IRoleService _roleService;

		public RoleController(IRoleService roleService)
		{
			_roleService = roleService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var roles = await _roleService.GetAll();
			return Ok(roles);
		}
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var roles = await _roleService.GetById(id);
            return Ok(roles);
        }
        [HttpPost("Create-Roles")]
		public async Task<IActionResult> Create([FromBody] RoleAddVM request)
		{
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
			var result = await _roleService.CreateRoles(request);
			if (!result) return BadRequest();
			return Ok();
          
        }
        [HttpDelete("Delete-Roles/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _roleService.DeleteRoles(Id);
            if (!result) return BadRequest();
            return Ok();

        }
        [HttpPut("Update-Roles/{Id}")]
        public async Task<IActionResult> Update(Guid Id,RoleAddVM request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _roleService.UpdateRoles(Id,request);
            if (!result) return BadRequest();
            return Ok();

        }
    }
}
