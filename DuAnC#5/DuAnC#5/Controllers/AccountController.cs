using BUS.Systems.Users;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using ViewModel.System.Roles;
using ViewModel.System.Users;

namespace DuAnC_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserService userService, ILogger<AccountController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.Register(request);
            if (!result)
            {
                return BadRequest("Register is unsuccessful.");
            }
            return Ok();
        }
        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterVM request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.RegisterUser(request);
            if (!result)
            {
                return BadRequest("Register is unsuccessful.");
            }
            return Ok();
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(LoginViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Authencate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("UserName or PassWord is incorrect");
            }
            return Ok(new { token = resultToken });
        }
        [HttpPost("login-google")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginGoogle(LoginViewModelGoogle request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.LoginGoogle(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("UserName or PassWord is incorrect");
            }
            return Ok(new { token = resultToken });
        }
        //[Authorize]
        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var user = await _userService.GetUsersPaging(request);
            return Ok(user);
        }
        [HttpGet("get-by-id/{Id}")]
        public async Task<IActionResult> getById(Guid Id)
        {
            var user = await _userService.GetById(Id);
            return Ok(user);
        }
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var user = await _userService.Delete(Id);
            return Ok(user);
        }
        [HttpPut("updateUser/{Id}")]
        public async Task<IActionResult> UpdateUser(Guid Id, [FromBody] UserUpdateViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UpdateUser(Id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(Guid id, RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RoleAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.ChangePassword(request);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
