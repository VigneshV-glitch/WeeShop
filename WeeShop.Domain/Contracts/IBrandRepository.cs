using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Domain.CommonFields;
using WeeShop.Domain.Models;

namespace WeeShop.Domain.Contracts
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task UpdateAsync (Brand brand);
    }
}
