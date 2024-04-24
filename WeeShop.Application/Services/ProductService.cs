using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Application.DTO.Product;
using WeeShop.Application.Pagination;
using WeeShop.Application.PaginationView;
using WeeShop.Application.Services.Interface;
using WeeShop.Domain.Contracts;
using WeeShop.Domain.Models;

namespace WeeShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPaginationService<ProductDTO, Product> _paginationService;
        private IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper, IPaginationService<ProductDTO, Product> paginationService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        public async Task<ProductDTO> CreateAsync(CreateProductDTO createProductDTO)
        {
            var UserToDb = _mapper.Map<Product>(createProductDTO);
            var DbOperation = await _productRepository.CreateAsync(UserToDb);
            return _mapper.Map<ProductDTO>(DbOperation);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(x => x.Id == id);
            await _productRepository.DeleteAsync(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllProductAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(x=> x.Id == id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            var product = _mapper.Map<Product>(updateProductDTO);
            await _productRepository.UpdateAsync(product);
        }

        public async Task<PaginationViewModel<ProductDTO>> GetPagination(PaginationModel paginationModel)
        {
            var source = await _productRepository.GetAllProductAsync();

            var result = _paginationService.GetPagination(source, paginationModel);

            return result;
        }

    }
}
