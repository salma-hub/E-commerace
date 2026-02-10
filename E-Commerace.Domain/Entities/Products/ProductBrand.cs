using E_commerace.Domain.Entities;
using E_Commerace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E_commerace.Domain.Entities.Products
{
    public class ProductBrand: BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
