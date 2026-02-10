using E_Commerace.Domain.Contracts;
using E_Commerace.Domain.Entities.Baskets;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerace.Persistence.Repoestories
{
    public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
    {
        private readonly IDatabase _database = connection.GetDatabase();
        public async Task<CustomerBasket?> CreateBasketAsync(CustomerBasket basket, TimeSpan duration)
        {
            var basketData=JsonSerializer.Serialize(basket);
            var flag= await _database.StringSetAsync(basket.Id, basketData, duration);
            if(!flag)
            {
                return null;
            }
            return await GetBasketAsync(basket.Id);
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
      
        }

        public async Task<CustomerBasket?> GetBasketAsync(string basketId)
        {
            var data =await  _database.StringGetAsync(basketId);
            if(data.IsNullOrEmpty)
            {
                return null;
            }
            var basketData=JsonSerializer.Deserialize<CustomerBasket>(data);
            if (basketData == null)
            {
                return null;
            }
            return basketData;
        }
    }
}
