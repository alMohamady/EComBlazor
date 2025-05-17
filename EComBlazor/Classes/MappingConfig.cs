using AutoMapper;
using EComBlazor.db.Entities;
using EComBlazor.lib.DTOs;

namespace EComBlazor.Classes
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<Product, GetProductDto>();
        }
    }
}
