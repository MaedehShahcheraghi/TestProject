using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;
using TP.Application.Requirements.AuthorizationRequiremnts;

namespace TP.Persistence.RequiermentsHandler.AuthorizationRequiremnts
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {

            string userName = context.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;

            if (await _permissionRepository.CheckPermissionUser(userName, requirement.PermissionName))
            {
                context.Succeed(requirement);
            }
        }
    }
}
