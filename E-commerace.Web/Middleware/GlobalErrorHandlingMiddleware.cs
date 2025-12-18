using E_commerace.Shared.ErrorModels;
using E_Commerace.Domain.Exception.NotFound;
using E_Commerace.Domain.Exceptions.BadRequest;
using E_Commerace.Domain.Exceptions.NotFound;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_commerace.Web.Middleware
{
    public class GlobalErrorHandlingMiddleware
    {
  
     private readonly RequestDelegate _next;
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync (HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
                if(context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                  
                     await context.Response.WriteAsJsonAsync(new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = $"The requested resource {context.Request.Path} was not found."
                    });
                }
            }
            catch (Exception ex) {

                context.Response.StatusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };
                context.Response.ContentType = "application/json";
                var response = new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message
                };
                await context.Response.WriteAsJsonAsync(response);
            }
         
        }
    }
}
