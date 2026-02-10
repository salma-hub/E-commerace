using AutoMapper;
using E_commerace.Services.Abstraction.IBasketService;
using E_commerace.Shared.Dtos.Baskets;
using E_Commerace.Domain.Contracts;
using E_Commerace.Domain.Entities.Baskets;
using E_Commerace.Domain.Exceptions.BadRequest;
using E_Commerace.Domain.Exceptions.NotFound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.Services
{
    public class BasketService(IBasketRepository _basketRepository,IMapper _mapper) : IBasketService
    {
        public async Task<BasketDto?> CreateBasketAsync(BasketDto basketData, TimeSpan duration)
        {
            var basketEntity = _mapper.Map<CustomerBasket>(basketData);
            var basket= await _basketRepository.CreateBasketAsync(basketEntity, duration);
            if (basketData == null)   throw new CreateOrUpdateBasketBadRequestException();
            var result = _mapper.Map<BasketDto>(basket);
            return result;
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
           var flag= await _basketRepository.DeleteBasketAsync(basketId);
            if (!flag)  throw new DeleteBasketBadRequestException();
            return flag;
        }

        public async Task<BasketDto?> GetBasketAsync(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            if (basket is null) throw new BasketNotFoundException(basketId);
            var result =  _mapper.Map<BasketDto>(basket);
            return result;
        }
    }
}
