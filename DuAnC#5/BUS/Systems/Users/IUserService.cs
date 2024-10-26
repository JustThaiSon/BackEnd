using BUS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.System;
using ViewModel.System.Roles;
using ViewModel.System.Users;

namespace BUS.Systems.Users
{
    public interface IUserService
    {
        Task<bool> Register(RegisterViewModel request);
        Task<bool> RegisterUser(RegisterVM request);
        Task<string> Authencate(LoginViewModel request);
        Task<string> LoginGoogle(LoginViewModelGoogle request);
        Task<PageResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request);
		Task<ApiResult<bool>> UpdateUser(Guid Id, UserUpdateViewModel request);
        Task<ApiResult<UserViewModel>> GetById(Guid id);
		Task<ApiResult<bool>> Delete(Guid id);
        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
        Task<ApiResult<bool>> ChangePassword(ChangePassword request);

    }
}
