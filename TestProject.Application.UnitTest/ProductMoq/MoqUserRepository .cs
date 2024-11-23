using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;
using TP.Domain;

namespace TestProject.Application.UnitTest.ProductMoq
{
    public class MoqUserRepository
    {
        public static Mock<IUserRepository> GetUserReposittory()
        {

            var hasher = new PasswordHasher<ApplicationUser>();
            var users=new List<ApplicationUser>() {
                new ApplicationUser()
                {
                    Id = "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                    Email = "Admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "Admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    FirstName = "Admin",
                    LastName = "Adminian",
                    PasswordHash = hasher.HashPassword(null, "P@swword1")
                },
                  new ApplicationUser()
                  {
                      Id = "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                      Email = "User@localhost.com",
                      NormalizedEmail = "USER@LOCALHOST.COM",
                      UserName = "User@localhost.com",
                      NormalizedUserName = "USER@LOCALHOST.COM",
                      FirstName = "System",
                      LastName = "User",
                      PasswordHash = hasher.HashPassword(null, "P@swword1")
                  }
                };
            var mockrepository = new Mock<IUserRepository>();
            mockrepository.Setup(r => r.ExistByIdAsync(It.IsAny<string>()))
          .ReturnsAsync((string id) => users.Any(u => u.Id == id));

            return mockrepository;


        }
    }
}
