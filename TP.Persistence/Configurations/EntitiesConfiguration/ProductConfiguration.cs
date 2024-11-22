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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Product Relation
            builder.HasOne(b => b.ApplicationUser).WithMany(b => b.Products).HasForeignKey(b => b.CreatedBy);

            //Product configuration
            builder.Property(e => e.Name)
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(e => e.ProduceDate)
                .IsRequired();

            builder.Property(e => e.ManufacturePhone)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.ManufactureEmail)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.IsAvailable)
                .IsRequired();

            //ManufactureEmail ProduceDate index 

            builder.HasIndex(e => new { e.ManufactureEmail, e.ProduceDate })
                .IsUnique();

            #region Seed data
            builder.HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Product 1",
                    ManufacturePhone = "09925772866",
                    ManufactureEmail = "maedeh.shahcheraghi1384@gmail.com",
                    ProduceDate = DateTime.Now,
                    CreatedBy = "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                    IsAvailable = true,
                },
                 new Product()
                 {
                     Id = 2,
                     Name = "Product 2",
                     ManufacturePhone = "09925772867",
                     ManufactureEmail = "maedeh.shahcheraghi2005@gmail.com",
                     ProduceDate = DateTime.Now,
                     CreatedBy = "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                     IsAvailable = true,
                 }
                );
            #endregion

        }
    }
}
