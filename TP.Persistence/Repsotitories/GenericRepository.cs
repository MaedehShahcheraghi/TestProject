using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TP.Persistence.Repsotitories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();

        }

        public async Task<bool> ExistByIdAsync(object id)
        {
           var enetity= await _dbSet.FindAsync(id);
            return enetity != null;

        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(object id)
        {
            var enetity = await _dbSet.FindAsync(id);
            return enetity;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
           _dbContext.Entry(entity).State=EntityState.Modified;
            await SaveChangesAsync();

        }
    }
}
