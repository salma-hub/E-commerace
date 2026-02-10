using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Shared.Dtos.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public string PictureUrl { get; init; }
        public string ProductBrand { get; init; }
        public string ProductType { get; init; }
    }
}
