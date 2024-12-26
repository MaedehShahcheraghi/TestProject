using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Domain
{
    public class RolePermission
    {
        public string RoleId { get; set; }
        public string PermssionId { get; set; }

        #region Relation
        [ForeignKey("RoleId")]
        public ApplicationRole ApplicationRole { get; set; }
        public Permission Permission { get; set; }
        #endregion
    }
}
