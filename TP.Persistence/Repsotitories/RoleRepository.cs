using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;
using TP.Domain;

namespace TP.Persistence.Repsotitories
{
    public class RoleRepository:GenericRepository<ApplicationRole>,IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleRepository(ApplicationDbContext dbContext,RoleManager<ApplicationRole> roleManager) : base(dbContext)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

     
    }
}
