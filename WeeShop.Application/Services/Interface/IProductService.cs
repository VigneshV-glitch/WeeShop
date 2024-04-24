using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Application.DTO.Product;
using WeeShop.Application.Pagination;
using WeeShop.Application.PaginationView;

namespace WeeShop.Application.Services.Interface
{
    public interface IProductService
    {
        Task<ProductDTO> CreateAsync (CreateProductDTO createProductDTO);

        Task<ProductDTO> GetByIdAsync(int id);

        Task<IEnumerable<ProductDTO>> GetAllAsync ();

        Task UpdateAsync (UpdateProductDTO updateProductDTO);

        Task DeleteAsync(int id);

        Task<PaginationViewModel<ProductDTO>> GetPagination(PaginationModel paginationModel);
    }
}
