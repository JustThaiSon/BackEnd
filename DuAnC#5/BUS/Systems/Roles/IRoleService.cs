using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.System.Roles;

namespace BUS.Systems.Roles
{
    public interface IRoleService
	{
		Task<List<RoleVM>> GetAll();
		Task<RoleVM> GetById(Guid Id);
		Task<bool>CreateRoles(RoleAddVM request);
		Task<bool>UpdateRoles(Guid Id, RoleAddVM request);
		Task<bool>DeleteRoles(Guid Id);
	}
}
