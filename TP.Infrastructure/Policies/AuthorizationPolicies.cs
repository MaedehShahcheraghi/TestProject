using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.ApplicationExtention.UserExtentions;
using TP.Application.Constants;

namespace TP.Infrastructure.Policies
{
    public static class AuthorizationPolicies
    {
        public static void AddPolicies(AuthorizationOptions options)
        {
            options.AddPolicy(CustomPloicy.AccessToManageUser, policy =>
                policy.RequireRole("Adminstrator")
                      .Build());

            options.AddPolicy(CustomPloicy.AccessToAddUserRole, policy =>
               policy.RequireRole("Adminstrator")
                     .Build());

            options.AddPolicy(CustomPloicy.AccessToManageProducts, policy =>
                policy.RequireRole("Adminstrator")
                      .Build());

            options.AddPolicy(CustomPloicy.AccessToReadProducts, policy =>
                policy.RequireRole("User", "Adminstrator", "Guest")
                      .Build());

            options.AddPolicy(CustomPloicy.AccessToAddProducts, policy =>
                policy.RequireRole("User", "Adminstrator")
                      .Build());

            options.AddPolicy(CustomPloicy.AccessToEditProducts, policy =>
                policy.RequireRole("User", "Adminstrator")
                      .Build());

            options.AddPolicy(CustomPloicy.AccessToDeleteProducts, policy =>
                policy.RequireRole("Adminstrator")
                      .Build());


            #region Ploicy with Permission

            options.AddPolicy(CustomPloicy.AccessToAddProducts, policy =>
       policy.RequirePermission(CustomPloicy.AccessToAddProducts));

            options.AddPolicy(CustomPloicy.AccessToManageProducts, policy =>
                policy.RequirePermission(CustomPloicy.AccessToManageProducts));
            #endregion
        }
    }
}
