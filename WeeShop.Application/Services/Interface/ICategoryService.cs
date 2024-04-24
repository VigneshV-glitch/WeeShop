using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Application.DTO.Category;

namespace WeeShop.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetbyIdAsync(int id);

        Task<IEnumerable<CategoryDTO>> GetAllAsync();

        Task<CategoryDTO> CreateAsync(CreateCategoryDTO createCategoryDTO);

        Task UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
        Task DeleteAsync(int id);
    }
}
