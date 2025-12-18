using E_commerace.Services.Abstraction.ICacheService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Presentation.Api.Controller
{
    public class CacheAttribute(int timeInSec) : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices
                        .GetRequiredService<ICacheService>();
            var cacheKey = GetCacheKey(context.HttpContext.Request);
            var result = await cacheService.GetAsync(cacheKey);
                if (!string.IsNullOrEmpty(result))
            {
                var response = new ContentResult
                {
                    Content = result,
                    ContentType = "applicatio/json",
                    StatusCode = 200
                };
                return;
            }
            var actionContext = await next.Invoke();
         
            if(actionContext.Result  is OkObjectResult okObjResult)
            {
                await cacheService.SetAsync(cacheKey, okObjResult.Value, TimeSpan.FromSeconds(timeInSec));
               
            }
        }
        private string GetCacheKey(HttpRequest httpRequest)
        {
            var key =new  StringBuilder();
            key.Append(httpRequest.Path);
            foreach(var item in httpRequest.Query)
            {
                key.Append($"|{item.Key}-{item.Value}");
            }
            return key.ToString();

        }
    }
}
