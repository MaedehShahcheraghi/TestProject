using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TP.Domain;

namespace TP.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #region Relations
        public ICollection<Product> Products { get; set; }
        public ICollection<ApplicationRole> ApplicationRoles { get; set; }
        #endregion
    }
}
