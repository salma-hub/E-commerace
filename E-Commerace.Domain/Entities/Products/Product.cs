using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Domain.Entities.Products
{
    public class Product: Entity<int>
    {
        public string? PictureUrl;

        public   string Name { get; set; }
        public string Description { get; set; }
        public string? PictureURL { get; set; }
        public decimal Price { get; set; }

        public ProductBrand ProductBrand { get; set; }
        public int BrandID { get; set; }
        public ProductType ProductType { get; set; }
        public int TypeID { get; set; }
    }
}
