using E_commerace.Shared.Dtos.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.Abstraction.IBasketService
{
    public interface IBasketService
    {
        Task<BasketDto?> CreateBasketAsync(BasketDto basketData, TimeSpan duration);
        Task<BasketDto?> GetBasketAsync (string basketId);
        Task<bool> DeleteBasketAsync (string basketId);
    }
}
