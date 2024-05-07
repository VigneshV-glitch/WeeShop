using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Application.DTO.Category;
using WeeShop.Application.Services.Interface;
using WeeShop.Domain.Contracts;
using WeeShop.Domain.Models;

namespace WeeShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _IcategoryRepository;
        private readonly IMapper _Imapper;
        public CategoryService(ICategoryRepository IcategoryRepository, IMapper mapper)
        {
            _IcategoryRepository = IcategoryRepository;
            _Imapper = mapper;
        }
        public async Task<CategoryDTO> CreateAsync(CreateCategoryDTO createCategoryDTO)
        {
            var FromDTO = _Imapper.Map<Category>(createCategoryDTO); //createCategoryDTO is a Source, Category is a Destination
            var CreatedEntity = await _IcategoryRepository.CreateAsync(FromDTO);
            return _Imapper.Map<CategoryDTO>(CreatedEntity);
        }
        //Source => Destination
        public async Task DeleteAsync(int id)
        {
            var category = await _IcategoryRepository.GetByIdAsync(x => x.Id == id);
            await _IcategoryRepository.DeleteAsync(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync() //Here the Task Returns the List Type, So the Return block                                                                          must have List, Convert the whatever type into List. 
        {
            var FromDB = await _IcategoryRepository.GetAllAsync();
            return _Imapper.Map<List<CategoryDTO>>(FromDB); 
        }

        public async Task<CategoryDTO> GetbyIdAsync(int id)
        {
            var category = await _IcategoryRepository.GetByIdAsync(x => x.Id == id);
            return _Imapper.Map<CategoryDTO>(category);
        }

        public async Task UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var FromDTO = _Imapper.Map<Category>(updateCategoryDTO);
            await _IcategoryRepository.UpdateAsync(FromDTO);
        }
    }
}