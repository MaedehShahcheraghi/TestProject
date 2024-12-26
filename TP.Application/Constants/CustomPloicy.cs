using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Application.Constants
{
    public class CustomPloicy
    {
        //User Product Accesss
        public const string AccessToManageUser = "AccessToManageUser";
        public const string AccessToAddUser = "AccessToAddUser";
        public const string AccessToDeleteUser = "AccessToDeleteUser";
        public const string AccessToEditUser = "AccessToEditUser";
        public const string AccessToReadUsers = "AccessToReadUsers";
        public const string AccessToAddUserRole= "AccessToAddUserRole";

        //Mange product access
        public const string AccessToManageProducts = "AccessToManageProducts";
        public const string AccessToAddProducts= "AccessToAddProducts";
        public const string AccessToDeleteProducts = "AccessToDeleteProducts";
        public const string AccessToReadProducts = "AccessToReadProducts";
        public const string AccessToEditProducts = "AccessToEditProducts";
    }
}
