using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Domain;

namespace TP.Persistence
{
    internal class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly TestProjectDbConext _testProjectDbContext;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, TestProjectDbConext testProjectDbContext)
            : base(options)
        {
            _testProjectDbContext = testProjectDbContext;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
           
        }

        #region SaveChangesConfiguration
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                if (entry.State != EntityState.Modified)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                if (entry.State != EntityState.Modified)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }
            return base.SaveChanges();
        }
        #endregion

        #region dbsets
        public DbSet<Product> Products => _testProjectDbContext.Products;
        #endregion

    }
}
