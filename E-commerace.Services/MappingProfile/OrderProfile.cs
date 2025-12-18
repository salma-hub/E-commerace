using AutoMapper;
using E_commerace.Shared.Dtos.Orders;
using E_Commerace.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.MappingProfile
{
    public class OrderProfile:Profile
    {
        public OrderProfile() { 
        CreateMap<Address,OrderAddress>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductId, o => o.MapFrom(src => src.ProductItemOrdered.ProductItemId))
                      .ForMember(dest => dest.ProductName, o => o.MapFrom(src => src.ProductItemOrdered.ProductName)).
                      ForMember(dest => dest.PictureUrl, o => o.MapFrom(src => src.ProductItemOrdered.PictureUrl));
            CreateMap<Order, OrderResponse>().
                ForMember(Dest=> Dest.DeliveryMethod,o=>o.MapFrom(src=>src.DeliveryMethod.ShortName)).
                ForMember(Dest=>Dest.Total,o=>o.MapFrom(src=>src.GetTotal()));
            CreateMap<DeliveryMethod, DelieveryMethodResponse>();
            
        }
    }
}
