using AutoMapper;
using E_commerace.Domain.Entities.Products;
using E_commerace.Services.Abstraction.I;
using E_commerace.Shared.Dtos.Products;
using E_Commerace.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.Services
{
    public class ProductService(IUnitOfWork unitOfWork,IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {

            var brands= await unitOfWork.GetRepository<ProductBrand, int>().GetAll();
           
            return mapper.Map<IEnumerable<BrandDto>>(brands);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetById(id);

            return mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var products = await unitOfWork.GetRepository<Product, int>().GetAll();

            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<TypeDto>> GetTypesAsync()
        {
            var types = await unitOfWork.GetRepository<ProductType, int>().GetAll();
            return mapper.Map<IEnumerable<TypeDto>>(types);
        }
    }
}
