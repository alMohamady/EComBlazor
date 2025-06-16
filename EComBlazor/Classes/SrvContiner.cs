using EComBlazor.Base;
using EComBlazor.lib.Base;
using EComBlazor.Services;
using EComBlazor.Services.Authentication;
using EComBlazor.Validations.Identity;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace EComBlazor.Classes
{
    public static class SrvContiner
    {
        public static IServiceCollection AddInjectionOptionsApi(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<ICategoryService, CategoryServices>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            services.AddValidatorsFromAssemblyContaining<LogInUserValidator>();

            services.AddScoped<IValidationServices, ValidationServices>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
