using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Domain;

namespace TP.Application.Contracts.Persistence
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Task<bool> CheckPermissionUser(string userName, string permissionName);
        Task<string> GetPermissionIdByName(string permissionName);

    }
}
