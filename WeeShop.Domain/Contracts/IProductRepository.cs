﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Domain.Models;

namespace WeeShop.Domain.Contracts
{
    public interface IProductRepository : IGenericRepository<Product> 
    {
        Task UpdateAsync(Product product);

        Task<List<Product>> GetAllProductAsync();
    }
}
