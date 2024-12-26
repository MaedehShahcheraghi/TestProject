using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Domain
{
    public class ApplicationRole:IdentityRole
    {

        #region Relations
        public ICollection<RolePermission> RolePermissions { get; set; }
        #endregion
    }
}
