using EComBlazor.lib.Base;
using EComBlazor.lib.Services;
using EComBlazor.Services;

namespace EComBlazor.Classes
{
    public static class SrvContiner
    {
        public static IServiceCollection AddInjectionOptions(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<ICategoryService, CategoryServices>();
            return services;
        }
    }
}
