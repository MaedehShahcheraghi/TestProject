using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TP.Domain;

namespace TP.Persistence.Configurations.EntitiesConfigurationy
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {

          

            //Add Seed Data

            builder.HasData(
                new ApplicationRole()
                {
                    Id = "f7c5524f-719a-4239-a167-4a61c4bcff01",
                    Name = "User",
                    NormalizedName = "USER",
                },
                new ApplicationRole()
                {
                    Id = "d43a6151-9461-4433-94fa-0b1170ee9f8d",
                    Name = "Adminstrator",
                    NormalizedName = "ADMINSTRATOR"
                },
                 new ApplicationRole()
                 {
                     Id = "d78a6151-9456-4433-93fa-0b1170ee9f8d",
                     Name = "Guest",
                     NormalizedName = "GUEST"
                 }
                );


        }
    }
}
