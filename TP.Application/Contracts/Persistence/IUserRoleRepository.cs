using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Application.Contracts.Persistence
{
    public interface IUserRoleRepository:IGenericRepository<IdentityUserRole<string>>
    {
        Task<ICollection<string>> GetIdentityUserRolesAsync(string userId);
    }
}
