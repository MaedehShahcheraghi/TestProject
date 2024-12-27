using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Requirements.AuthorizationRequiremnts;

namespace TP.Application.ApplicationExtention.UserExtentions
{
    public static class AuthorizationPolicyBuilderExtensions
    {
        public static AuthorizationPolicyBuilder RequirePermission(
        this AuthorizationPolicyBuilder builder,
        string permissionName)
        {
            return builder.AddRequirements(new PermissionRequirement(permissionName));
        }
    }
}
