using AutoMapper;
using E_commerace.Domain.Entities.Products;
using E_commerace.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace E_commerace.Services.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile(IConfiguration configuration)
        {
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(des => des.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(des => des.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(des => des.PictureUrl,  opt => opt.MapFrom (new ProductURLResolver(configuration)))
                ;
        }
    }

        public class ProductURLResolver: IValueResolver<Product, ProductDto, string>
        {
            private readonly IConfiguration _configuration;
            public ProductURLResolver(IConfiguration configuration)
            {
                _configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {


            return (_configuration["BaseUrl"] +source.PictureURL);
               
            }
        }
    }
