using E_commerace.Services.MappingProfile;
using E_commerace.Shared.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services
{
    public static class ApplicationServicesRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAutoMapper(x => x.AddProfile(new ProductProfile(configuration)));
            services.AddAutoMapper(x => x.AddProfile(new BasketProfile()));
            services.AddAutoMapper(x => x.AddProfile(new OrderProfile()));
            //  services.AddAutoMapper(typeof(ProductProfile));

            return services;
        }
         
    }
}
