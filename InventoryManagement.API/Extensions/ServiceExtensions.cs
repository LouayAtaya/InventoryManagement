
using InventoryManagement.API.ActionFilters;
using InventoryManagement.Application.Contracts;
using InventoryManagement.Application.Helpers;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces.Helpers;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Infrastructure.Data;
using InventoryManagement.Infrastructure.Helpers;
using InventoryManagement.Infrastructure.Repositories;
using InventoryManagement.Services;
using InventoryManagement.Services.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.API.Extensions
{
    public static class ServiceExtensions
    {
        /**
         * configure CORS in our application. 
         * CORS (Cross-Origin Resource Sharing) is a mechanism that gives rights to the user to access resources from the server on a different domain
         * 
         */
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        /**
         * configure an IIS integration that will help us with the IIS deployment
         */
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        //add the logger service inside the .NET Core’s IOC container
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        //configuring the sql server context, add the context service to the IOC
        public static void ConfigureSqlServerDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration["ConnectionStrings:sqlConnection"];

            services.AddDbContext<InventoryManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

            /*services.AddDbContext<InventoryManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    opt => opt.MigrationsAssembly("InventoryManagement")));*/
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<ISortHelper<Item>, SortHelper<Item>>();


            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
        }

        //disabling the automatic validation
        public static void ConfigureAutomaticValidation(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options
                => options.SuppressModelStateInvalidFilter = true);
        }

        public static void ConfigureValidationFilterAttribute(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();

        }

        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://InventoryManagement.com",
                    ValidAudience = "https://InventoryManagement.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@5215"))
                };
            });

        }

    }
}
