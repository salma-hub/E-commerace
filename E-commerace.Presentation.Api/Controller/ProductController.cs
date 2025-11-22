
using E_commerace.Services.Abstraction.I;
using E_commerace.Shared.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Presentation.Api.Controller
{
    public class ProductController(IProductService productService): APIBaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrandsAsync()
        {

            var brands = await productService.GetBrandsAsync();

            return Ok(brands);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsAsync([FromQuery]ProductQueryParameters productQuery)
        {
            var products = await productService.GetProductsAsync(productQuery);

            return Ok(products);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetTypesAsync()
        {
            var types = await productService.GetTypesAsync();

            return Ok(types);
        }
    }

}
