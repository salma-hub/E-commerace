
using E_commerace.Domain.Entities.Products;
using E_commerace.Persistence;
using E_commerace.Persistence.Context;
using E_commerace.Persistence.DbInitailzers;
using E_commerace.Persistence.Repoestories;
using E_commerace.Services;
using E_commerace.Services.Abstraction.I;
using E_commerace.Services.MappingProfile;
using E_commerace.Services.Sepecification;
using E_commerace.Services.Services;
using E_commerace.Shared.ErrorModels;
using E_commerace.Web.Middleware;
using E_Commerace.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerace.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAllServices(builder.Configuration);  
            var app = builder.Build();
            app.ConfigureWebApp();

            app.Run();
        }
    }
}
