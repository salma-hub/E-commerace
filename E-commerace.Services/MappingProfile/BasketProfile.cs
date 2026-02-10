using AutoMapper;
using E_commerace.Shared.Dtos.Baskets;
using E_Commerace.Domain.Entities.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.MappingProfile
{
    public class BasketProfile:Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketItems, BasketItemDto>().ReverseMap();
            CreateMap<CustomerBasket, BasketDto>().ReverseMap();
        }
    }
}
