using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Domain;

namespace TP.Persistence
{
    public class TestProjectDbConext:DbContext
    {
        public TestProjectDbConext(DbContextOptions<TestProjectDbConext> options):base(options)
        {
            
        }

        #region Product Dbset
        public DbSet<Product> Products { get; set; }
        #endregion
    }
}
