using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Domain;

namespace TP.Application.Contracts.Persistence
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<IReadOnlyList<Product>> GetProductsByOwnerId( string ? createBy );   
        Task<bool> ExistProductByEmailandPrdouctDate( string manufactureEmail,DateTime produceDate);   
    }
}
