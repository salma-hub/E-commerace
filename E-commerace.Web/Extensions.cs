using E_commerace.Persistence;
using E_commerace.Services;
using E_commerace.Shared.ErrorModels;
using E_commerace.Web.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace E_commerace.Web
{
    public static class Extensions
    {
        public static IServiceCollection AddAllServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.

            services.AddControllers();
            services.AddInfrasturctureServices(configuration);

            services.AddApplicationServices(configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<ApiBehaviorOptions>(config =>
          {
              config.InvalidModelStateResponseFactory = actionContext =>
              {
                  var errors = actionContext.ModelState.Where(model => model.Value.Errors.Any())
                  .Select(m => new ValidationErrors()
                  {
                      FieldName = m.Key,
                      Message =
                      m.Value.Errors.Select(e => e.ErrorMessage)
                  }
                  ).ToList();
                  var errorResponse = new ValidationErrorResponse()
                  {
                      Errors = errors
                  };
                  return new BadRequestObjectResult(errorResponse);
              };
          });
            return services;
        }


        public static WebApplication ConfigureWebApp(this WebApplication app)
        {

            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            return app;
        }
    }
}
