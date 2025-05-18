using EComBlazor.db.Base;
using EComBlazor.db.Contexts;
using EComBlazor.db.Entities;
using EComBlazor.db.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Services
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInjectionOptionsDb(this IServiceCollection services, IConfiguration conf)
        {
            string conStr = "ConStr";
            string? con = conf.GetConnectionString(conStr);
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(con,
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly);
                    sqlOptions.EnableRetryOnFailure();
                }),
                ServiceLifetime.Scoped
                );
            services.AddScoped<IGenralRepo<Category>, GenralRepo<Category>>();
            services.AddScoped<IGenralRepo<Product>, GenralRepo<Product>>();
            return services;
        }
    }
}
