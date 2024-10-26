using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.System.Roles;

namespace BUS.Systems.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRoles> _roleManager;

        public RoleService(RoleManager<AppRoles> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoles( RoleAddVM request)
        {
            var roleExist = await _roleManager.RoleExistsAsync(request.Name);
            if (!roleExist)
            {
                var addRole = new AppRoles()
                {
                    Name = request.Name,
                    Description = request.Description,
                };
                var result = await _roleManager.CreateAsync(addRole);
                return result.Succeeded;
            }
            return false;
        }

        public async Task<bool> DeleteRoles(Guid Id)
        {
            var roles = await _roleManager.FindByIdAsync(Id.ToString());
            if (roles != null)
            {
                var result = await _roleManager.DeleteAsync(roles);
                return result.Succeeded;
            }
            return false;
        }

        public async Task<List<RoleVM>> GetAll()
        {
            var roles = await _roleManager.Roles
               .Select(x => new RoleVM()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description
               }).ToListAsync();

            return roles;
        }

        public async Task<RoleVM> GetById(Guid Id)
        {
            var roles = await _roleManager.FindByIdAsync(Id.ToString());
            var roleVm = new RoleVM
            {
                Id = roles.Id,
                Name = roles.Name,
               Description= roles.Description
            };
            return roleVm;
        }

        public async Task<bool> UpdateRoles(Guid Id, RoleAddVM request)
        {
            var roles = await _roleManager.FindByIdAsync(Id.ToString());
            if (roles != null)
            {
                roles.Name = request.Name;
                roles.Description = request.Description;
                var result = await _roleManager.UpdateAsync(roles);
                return result.Succeeded;
            }
            return false;
        }
    }
}
