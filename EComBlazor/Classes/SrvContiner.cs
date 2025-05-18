using EComBlazor.lib.Base;
using EComBlazor.Services;

namespace EComBlazor.Classes
{
    public static class SrvContiner
    {
        public static IServiceCollection AddInjectionOptionsApi(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<ICategoryService, CategoryServices>();
            return services;
        }
    }
}
