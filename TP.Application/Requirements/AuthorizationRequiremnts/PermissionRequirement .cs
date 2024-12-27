using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Application.Requirements.AuthorizationRequiremnts
{
    public class PermissionRequirement(string permissionName): IAuthorizationRequirement
    {
        public string PermissionName { get; set; } = permissionName;
    }
}
