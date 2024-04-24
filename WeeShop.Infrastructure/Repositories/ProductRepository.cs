using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Domain.Contracts;
using WeeShop.Domain.Models;
using WeeShop.Infrastructure.DbContexts;

namespace WeeShop.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _dbContext.Product.Include(x => x.Category).Include(x => x.Brand).AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
