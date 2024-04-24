using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Application.DTO.Brand;
using WeeShop.Application.DTO.Category;
using WeeShop.Application.Services.Interface;
using WeeShop.Domain.Contracts;
using WeeShop.Domain.Models;

namespace WeeShop.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<BrandDTO> CreateAsync(CreateBrandDTO createBrandDTO)
        {
            var FromDB = _mapper.Map<Brand>(createBrandDTO);
            var CreatedEntity = await _brandRepository.CreateAsync(FromDB);
            return _mapper.Map<BrandDTO>(CreatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var Entity = await _brandRepository.GetByIdAsync(x => x.Id == id);
            await _brandRepository.DeleteAsync(Entity);
        }

        public async Task<IEnumerable<BrandDTO>> GetAllAsync()
        {
            var Entity = await _brandRepository.GetAllAsync();
            return _mapper.Map<List<BrandDTO>>(Entity);
        }

        public async Task<BrandDTO> GetByIdAsync(int id)
        {
            var Entity = await _brandRepository.GetByIdAsync(x => x.Id == id);
            return _mapper.Map<BrandDTO>(Entity);
        }

        public async Task UpdateAsync(UpdateBrandDTO updateBrandDTO)
        {
            var brand = _mapper.Map<Brand>(updateBrandDTO);
            await _brandRepository.UpdateAsync(brand);
        }
    }
}