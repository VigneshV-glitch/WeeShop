using AutoMapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Application.DTO.Brand;
using WeeShop.Application.DTO.Category;
using WeeShop.Application.DTO.Product;
using WeeShop.Domain.Models;

namespace WeeShop.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();
            CreateMap<Brand, UpdateBrandDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.Category, opt => opt.MapFrom(source => source.Category.CategoryName))
                .ForMember(x => x.Brand, opt => opt.MapFrom(source => source.Brand.Name));
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
        }
    }
}
