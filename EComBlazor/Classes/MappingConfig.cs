using AutoMapper;
using EComBlazor.db.Entities;
using EComBlazor.db.Entities.Identity;
using EComBlazor.db.Entities.Payments;
using EComBlazor.lib.DTOs;
using EComBlazor.lib.DTOs.Identity;
using EComBlazor.lib.DTOs.Payments;

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
            CreateMap<PaymentMethodDto, PaymentMethod>();
        }
    }
}
