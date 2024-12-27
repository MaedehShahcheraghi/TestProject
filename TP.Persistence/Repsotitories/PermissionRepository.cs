using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;
using TP.Domain;

namespace TP.Persistence.Repsotitories
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public PermissionRepository(ApplicationDbContext dbContext, IUserRoleRepository userRoleRepository, IRolePermissionRepository
            rolePermissionRepository, UserManager<ApplicationUser> userManager) : base(dbContext)
        {
            _dbContext = dbContext;
            _userRoleRepository = userRoleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _userManager = userManager;
        }

        public async Task<bool> CheckPermissionUser(string userName, string permissionName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
               
                var UserrolesName = await _userRoleRepository.GetIdentityUserRolesAsync(user.Id);

                var permissions = await _dbContext.rolePermissions.Include(r => r.ApplicationRole)
                    .Where(rp => UserrolesName.Contains(rp.ApplicationRole.Name))
                    .Select(rp => rp.Permission.PermissionTitle)
                    .ToListAsync();
                if (permissions.Contains(permissionName))
                {
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);

            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<string> GetPermissionIdByName(string permissionName)
        {
            return await _dbContext.Permission.Where(u => u.PermissionTitle == permissionName).Select(u => u.PermissionId).FirstOrDefaultAsync();
        }
    }
}
