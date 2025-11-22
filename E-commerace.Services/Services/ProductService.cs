using AutoMapper;
using E_commerace.Domain.Entities.Products;
using E_commerace.Services.Abstraction.I;
using E_commerace.Services.Sepecification;
using E_commerace.Shared;
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
            var specs = new ProductWithTypeAndSepecification(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(specs);

            return mapper.Map<ProductDto>(product);
        }

        public async Task<PaginateResult<ProductDto>> GetProductsAsync(ProductQueryParameters productQuery)
        {   var specs = new ProductWithTypeAndSepecification(productQuery);
            var countSpecs = new ProductcountSecification(productQuery);
            var totalCount= await unitOfWork.GetRepository<Product, int>().CountAsync(countSpecs);
            var products = await unitOfWork.GetRepository<Product, int>().GetAll(specs);

            var result= mapper.Map<IEnumerable<ProductDto>>(products);
            return new PaginateResult<ProductDto>(productQuery.PageIndex, result.Count(), totalCount, result);
        }

     

        public async Task<IEnumerable<TypeDto>> GetTypesAsync()
        {
            var types = await unitOfWork.GetRepository<ProductType, int>().GetAll();
            return mapper.Map<IEnumerable<TypeDto>>(types);
        }
    }
}
