using AutoMapper;
using E_commerace.Domain.Entities.Products;
using E_commerace.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.MappingProfile
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductBrand ,BrandDto>();
            CreateMap<ProductType, TypeDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(des => des.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(des => des.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                ;
        }
    }
}
