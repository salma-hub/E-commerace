using E_commerace.Services.Abstraction.IBasketService;
using E_commerace.Shared.Dtos.Baskets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Presentation.Api.Controller
{
    public class BasketsController(IBasketService basketService): APIBaseController
    {
      
        [HttpGet] //baseurl/api/baskets?id
        public async Task<IActionResult> GetBasketById(  string Id)
        {
            var result= await basketService.GetBasketAsync(Id);
            return Ok(result);
        }

        [HttpDelete] //baseurl/api/baskets?id
        public async Task<IActionResult> DeleteBasketById( string Id)
        {
            var result = await basketService.DeleteBasketAsync(Id);
            return NoContent();
        }
        [HttpPost] //baseurl/api/baskets
        public async Task<IActionResult> CreateorUpdateBasketById( BasketDto basketDto)
        {
            var result = await basketService.CreateBasketAsync(basketDto,TimeSpan.FromDays(1));
            return Ok(result);
        }
    }
}
