using E_commerace.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.Abstraction.I
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(ProductQueryParameters productQuery);
        Task<IEnumerable<TypeDto>> GetTypesAsync();
        Task<IEnumerable<BrandDto>> GetBrandsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);

    }
}
