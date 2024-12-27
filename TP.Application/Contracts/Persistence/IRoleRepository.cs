using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Domain;

namespace TP.Application.Contracts.Persistence
{
    public interface IRoleRepository:IGenericRepository<ApplicationRole>
    {
     
    }
}
