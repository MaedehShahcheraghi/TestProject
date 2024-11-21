using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Persistence.Configurations.EntitiesConfigurationy
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole()
                {
                    Id = "f7c5524f-719a-4239-a167-4a61c4bcff01",
                    Name = "User",
                    NormalizedName = "USER",
                },
                new IdentityRole()
                {
                    Id = "d43a6151-9461-4433-94fa-0b1170ee9f8d",
                    Name = "Adminstrator",
                    NormalizedName = "ADMINSTRATOR"
                });
        }
    }
}
