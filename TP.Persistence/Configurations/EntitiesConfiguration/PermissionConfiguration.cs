using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Domain;

namespace TP.Persistence.Configurations.EntitiesConfiguration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder
            .HasMany(p => p.Permissions) 
            .WithOne() 
            .HasForeignKey(p => p.ParentId);
        }
    }
}
