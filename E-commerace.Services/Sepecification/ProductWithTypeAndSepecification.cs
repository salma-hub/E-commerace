using E_commerace.Domain.Entities.Products;
using E_commerace.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Services.Sepecification
{
    public class ProductWithTypeAndSepecification : BaseSecficiation<Product>
    {
        public ProductWithTypeAndSepecification(ProductQueryParameters parameters)
            : base(CreateCriteria(parameters))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
        public ProductWithTypeAndSepecification(int Id)
          : base(x=>x.Id==Id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }

        private static Expression<Func<Product, bool>> CreateCriteria
                (ProductQueryParameters parameters)
        {
            return x =>
                (!parameters.BrandId.HasValue || x.BrandID == parameters.BrandId) &&

                (!parameters.TypeId.HasValue || x.TypeID == parameters.TypeId);
        }
    }
    }
