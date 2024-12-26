using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Domain
{
    public class Permission
    {
        public string PermissionId { get; set; }
        public string PermissionTitle { get; set; }
        public string? ParentId { get; set; }

        #region Relations
        [ForeignKey("ParentId")]
        public List<Permission> Permissions { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
        #endregion
    }
}
