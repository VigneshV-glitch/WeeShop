using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Application.DTO.Brand;

namespace WeeShop.Application.Services.Interface
{
    public interface IBrandService
    {
        Task<BrandDTO> GetByIdAsync(int id);

        Task<IEnumerable<BrandDTO>> GetAllAsync();

        Task<BrandDTO> CreateAsync(CreateBrandDTO createBrandDTO);

        Task UpdateAsync(UpdateBrandDTO updateBrandDTO);

        Task DeleteAsync(int id);
    }
}
