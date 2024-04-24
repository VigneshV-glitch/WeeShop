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
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task UpdateAsync(Brand brand)
        {
            _dbContext.Update(brand);
            await _dbContext.SaveChangesAsync();
        }
    }
}
