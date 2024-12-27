using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TP.Application.Contracts.Persistence;
using TP.Application.Responses;
using System.Security.Claims;

namespace TestProject.Api.AttributeFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PermissionCheckerAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _permissionName;

        public PermissionCheckerAttribute(string permissionName)
        {
            _permissionName = permissionName;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var permissionService = (IPermissionRepository)context.HttpContext.RequestServices.GetService(typeof(IPermissionRepository));

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = context.HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userName))
                {
                    context.Result = new RedirectResult("/Login");
                    return;
                }

                var hasPermission = await permissionService.CheckPermissionUser(userName, _permissionName);

                if (!hasPermission)
                {
                    var result = new BaseAttribiuteResponse()
                    {
                        StatusCode = "403",
                        ErrorMessage = "You don't have permission",
                        StatusMessage = "Permission Denied"
                    };

                    context.Result = new JsonResult(result)
                    {
                        StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden
                    };
                    return;
                }

                // ادامه اجرای اکشن
                await next();
            }
            else
            {
                context.Result = new RedirectResult("/Login");
            }
        }
    }
}
