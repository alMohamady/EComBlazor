using EComBlazor.db.Base;
using EComBlazor.db.Base.Authentication;
using EComBlazor.db.Contexts;
using EComBlazor.db.Entities;
using EComBlazor.db.Entities.Identity;
using EComBlazor.db.Repos;
using EComBlazor.db.Repos.Authentication;
using EComBlazor.lib.Base;
using EComBlazor.lib.Exceptions;
using EComBlazor.lib.Services;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
                }).UseExceptionProcessor(),
                ServiceLifetime.Scoped
                );
            services.AddScoped<IGenralRepo<Category>, GenralRepo<Category>>();
            services.AddScoped<IGenralRepo<Product>, GenralRepo<Product>>();
            services.AddScoped(typeof(IAppLoger<>), typeof(SerilogAppAdapter<>));

            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedPhoneNumber = true;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true, 
                    ValidIssuer = conf["JWT:Issuer"], 
                    ValidAudience = conf["JWT:Audience"], 
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["JWT:Key"]!))
                };
            });
            services.AddScoped<IUserManagement, UserManagement>();
            services.AddScoped<ITokenManagement, TokenManagement>();
            services.AddScoped<IRoleManagment, RoleManagment>();
            return services;
        }

        public static IApplicationBuilder AddMiddleWareDb(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExHandlingMiddleware>();
            return app;
        }
    }
}
