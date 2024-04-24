using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Domain.CommonFields;
using WeeShop.Domain.Contracts;
using WeeShop.Infrastructure.DbContexts;

namespace WeeShop.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T Entity)
        {
            var AddRecord = await _dbContext.Set<T>().AddAsync(Entity);
            await _dbContext.SaveChangesAsync();
            return AddRecord.Entity;
        }

        public async Task DeleteAsync(T Entity)
        {
            _dbContext.Remove(Entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> condition)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(condition);
        }
    }
}