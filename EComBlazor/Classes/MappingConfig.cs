using AutoMapper;
using EComBlazor.db.Entities;
using EComBlazor.db.Entities.Identity;
using EComBlazor.lib.DTOs;
using EComBlazor.lib.DTOs.Identity;
using EComBlazor.Validations.Identity;

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
            CreateMap<CreateUser, AppUser>();
            CreateMap<LogInUser, AppUser>();
        }
    }
}
