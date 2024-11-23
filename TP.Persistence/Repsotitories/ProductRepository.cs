using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;
using TP.Domain;

namespace TP.Persistence.Repsotitories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext ):base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistProductByEmailandPrdouctDate(string manufactureEmail, DateTime produceDate)
        {
            return await _dbContext.Products.Where(c=> c.ManufactureEmail==manufactureEmail && c.ProduceDate==produceDate).AnyAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsByOwnerId(string? createBy)
        {
            IQueryable<Product> result =  _dbContext.Products;
            if (!string.IsNullOrEmpty(createBy))
            {
             result=result.Where(p=> p.CreatedBy==createBy);
            }
            return await result.ToListAsync();
        }
    }
}
