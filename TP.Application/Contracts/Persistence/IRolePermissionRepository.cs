using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Domain;

namespace TP.Application.Contracts.Persistence
{
    public interface IRolePermissionRepository : IGenericRepository<RolePermission>
    {
        Task<ICollection<RolePermission>> GetAllRolesForPermission(string peremissionId);
    }
}
