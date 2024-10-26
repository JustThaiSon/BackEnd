using BUS.Common;
using DAL.Entities;
using DAL.Enum;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModel.System;
using ViewModel.System.Roles;
using ViewModel.System.Users;

namespace BUS.Systems.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRoles> _roleManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRoles> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<string> Authencate(LoginViewModel request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null;
            var result = await _signInManager.PasswordSignInAsync(user, request.PassWord, request.Rememberme ?? false, true);
            if (!result.Succeeded)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.Name),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ApiResult<bool>> ChangePassword(ChangePassword request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            if (request.NewPassword != request.ConfirmPassword)
            {
                return new ApiErrorResult<bool>("Mật khẩu mới không khớp");
            }
            var isCurrentPasswordValid = await _userManager.CheckPasswordAsync(user, request.CurrentPassword);
            if (!isCurrentPasswordValid)
            {
                return new ApiErrorResult<bool>("Mật khẩu hiện tại không đúng");
            }
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>($"Đổi mật khẩu không thành công");
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Xóa không thành công");
        }

        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
            var user = await _userManager.Users.Include(u => u.AddressUsers).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return new ApiErrorResult<UserViewModel>("User không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Dob = user.Dob,
                PassWord = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                Roles = roles.ToList(),
                Addresses = user.AddressUsers?.Select(a => new AddressViewModel
                {
                    Id = a.Id,
                    ProvinceName = a.ProvinceName,
                    ProvinceId = a.ProvinceId,
                    DistrictId = a.DistrictId,
                    DistrictName = a.DistrictName,
                    WardName = a.WardName,
                    WardId = a.WardId,
                    Description = a.Description
                }).ToList() ?? new List<AddressViewModel>()
            };
            return new ApiSuccessResult<UserViewModel>(userViewModel);
        }

        public async Task<PageResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users.Include(u => u.AddressUsers).AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.Keyword) || x.PhoneNumber.Contains(request.Keyword));
            }

            var totalRecords = await query.CountAsync();

            var users = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                   .Take(request.PageSize)
                                   .ToListAsync();

            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                userViewModels.Add(new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Dob = user.Dob,
                    Roles = roles,
                    Addresses = user.AddressUsers.Select(a => new AddressViewModel
                    {
                        Id = a.Id,
                        ProvinceName = a.ProvinceName,
                        ProvinceId = a.ProvinceId,
                        DistrictId = a.DistrictId,
                        DistrictName = a.DistrictName,
                        WardName = a.WardName,
                        WardId = a.WardId,
                        Description = a.Description
                    }).ToList()
                });
            }

            var pageResult = new PageResult<UserViewModel>
            {
                Items = userViewModels,
                TotalRecords = totalRecords
            };

            return pageResult;
        }

        public async Task<string> LoginGoogle(LoginViewModelGoogle request)
        {
            var idToken = request.IdToken;
            var setting = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new string[] { "477409344682-hff44d7rkjcqls41bju8m3sl3ilovgm4.apps.googleusercontent.com" }
            };
            var result = await GoogleJsonWebSignature.ValidateAsync(idToken, setting);
            var claims = new[]
                    {
                        new Claim("Email", result.Email),
                        new Claim(ClaimTypes.GivenName,result.Name),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterViewModel request)
        {

            var user = new AppUser()
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Name,
                Dob = request.Dob,
                PhoneNumber = request.PhoneNumber,
                AddressUsers = new List<Address>
                {
                    new Address
                    {
                        ProvinceName = request.ProvinceName,
                        ProvinceId = request.ProvinceId,
                        DistrictId = request.DistrictId,
                        DistrictName = request.DistrictName,
                        WardName = request.WardName,
                        WardId = request.WardId,
                        Description = request.Description
                    }
                },
                Status = StatusUserEnum.Active
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return false;

            return true;
        }

        public async Task<bool> RegisterUser(RegisterVM request)
        {
            var user = new AppUser()
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Name,
                Dob = request.Dob,
                PhoneNumber = request.PhoneNumber,
                Status = StatusUserEnum.Active
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return false;

            return true;
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại");
            }
            //lấy ra role hiện tại
            var currentRoles = await _userManager.GetRolesAsync(user);
            //xóa những roles không được tick
            var removeRoles = currentRoles.Where(role => !request.roles.Any(r => r.Selected
            && r.Name == role)).ToList();

            foreach (var roleName in removeRoles)
            {
                await _userManager.RemoveFromRoleAsync(user, roleName);
            }
            var addedRoles = request.roles
                   .Where(r => r.Selected && !currentRoles.Contains(r.Name))
                   .Select(r => r.Name)
                   .ToList();
            foreach (var roleName in addedRoles)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> UpdateUser(Guid Id, UserUpdateViewModel request)
        {
            var userAny = await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != Id);
            if (userAny) return new ApiErrorResult<bool>("Emai đã tồn tại");
            var user = await _userManager.FindByIdAsync(Id.ToString());
            user.Name = request.Name;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.Dob = request.Dob;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

    }
}
