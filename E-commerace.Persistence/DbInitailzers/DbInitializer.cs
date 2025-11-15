using E_commerace.Domain.Entities.Products;
using E_commerace.Persistence.Context;
using E_Commerace.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerace.Persistence.DbInitailzers
{
    public class DbInitializer(StoreDbContext storeDbContext) : IDbInitializer
    {
        public void Initialize()
        {
            storeDbContext.Database.Migrate();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            if (!storeDbContext.ProductBrands.Any())
            {
                var brands = File.ReadAllText(@"D:\C#\API\E-commerace\E-commerace.Persistence\Context\DataSeed\JSONFiles\brands.json");
                var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(brands, options);
                if (productBrands is not null && productBrands.Count > 0)
                {
                    storeDbContext.ProductBrands.AddRange(productBrands);

                }
            }
            if (!storeDbContext.ProductTypes.Any())
            {
                var types = File.ReadAllText(@"D:\C#\API\E-commerace\E-commerace.Persistence\Context\DataSeed\JSONFiles\types.json");
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(types, options);
                if (productTypes is not null && productTypes.Count > 0)
                {
                    storeDbContext.ProductTypes.AddRange(productTypes);
                }
            }
            if (!storeDbContext.Products.Any())
            {
                var products = File.ReadAllText(@"D:\C#\API\E-commerace\E-commerace.Persistence\Context\DataSeed\JSONFiles\products.json");
                var productList = JsonSerializer.Deserialize<List<Product>>(products, options);
                if (productList is not null && productList.Count > 0)
                {
                    storeDbContext.Products.AddRange(productList);

                }
            }
            storeDbContext.SaveChanges();
        }
    }
}