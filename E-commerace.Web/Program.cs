
using E_commerace.Persistence.Context;
using E_commerace.Persistence.DbInitailzers;
using E_commerace.Persistence.Repoestories;
using E_commerace.Services.Abstraction.I;
using E_commerace.Services.MappingProfile;
using E_commerace.Services.Services;
using E_Commerace.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace E_commerace.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //Dependecy Injection for Interfaces and Implementations
//            Whenever someone asks for an object of type IDbInitializer,
//give them an instance of the class DbInitializer.
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
            });
            builder.Services.AddAutoMapper(x => x.AddProfile(new ProductProfile()));
            using var scope = builder.Services.BuildServiceProvider().CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            initializer.Initialize();
         
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           
            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
