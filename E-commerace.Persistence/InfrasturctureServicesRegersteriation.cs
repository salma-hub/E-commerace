using E_commerace.Persistence.Context;
using E_commerace.Persistence.DbInitailzers;
using E_commerace.Persistence.Identity.Context;
using E_commerace.Persistence.Repoestories;
using E_commerace.Services.Abstraction.I;
using E_commerace.Services.Abstraction.IBasketService;
using E_commerace.Services.Abstraction.ICacheService;
using E_commerace.Services.Abstraction.IOrderService;
using E_commerace.Services.MappingProfile;
using E_commerace.Services.Services;
using E_commerace.Shared.ErrorModels;
using E_Commerace.Domain.Contracts;
using E_Commerace.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace E_commerace.Persistence
{    public static class InfrasturctureServicesRegersteriation
    {
        public static async Task<IServiceCollection> AddInfrasturctureServices(this IServiceCollection services ,IConfiguration configuration)
        {
     

            services.AddScoped<IDbInitializer, DbInitializer>();
             services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ICacheRepository, CacheRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddSingleton<IConnectionMultiplexer>(ServiceProvider =>
           
            {
                var connectionString = configuration.GetConnectionString("RedisConnection");
                return ConnectionMultiplexer.Connect(connectionString);
            });
         
            //    builder.Services.AddScoped<IBaseSpecification<TEntity>, BaseSecficiation<>();
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });
            //Dependecy Injection for Interfaces and Implementations
            //            Whenever someone asks for an object of type IDbInitializer,
            //give them an instance of the class DbInitializer.
            services.AddIdentityCore<AppUser>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();
            using var scope = services.BuildServiceProvider().CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            initializer.Initialize();
        await     initializer.IdentityInitialize();


            return services;
        }
        
    }
}
