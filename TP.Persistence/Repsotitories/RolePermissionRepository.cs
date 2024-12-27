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
    public class RolePermissionRepository:GenericRepository<RolePermission>, IRolePermissionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RolePermissionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<RolePermission>> GetAllRolesForPermission(string permissionName)
        {
            return await _dbContext.rolePermissions.Include(p=> p.Permission).Include(p=> p.ApplicationRole).Where(x => x.Permission.PermissionTitle == permissionName).ToListAsync();
        }
    }
}
