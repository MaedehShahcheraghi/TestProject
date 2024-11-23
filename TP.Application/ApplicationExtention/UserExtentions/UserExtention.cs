using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TP.Application.ApplicationExtention.UserExtention
{
    public static class UserExtention
    {
        public static string? GetUserId(this ClaimsPrincipal principal)
        {
           return  principal.Claims.Where(c => c.Type == CustomClaimTypes.Uid).FirstOrDefault()?.Value;
        }
    }
}
