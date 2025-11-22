
        using E_commerace.Domain.Entities.Products;
using E_commerace.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static E_commerace.Shared.Dtos.Products.ProductQueryParameters;

namespace E_commerace.Services.Sepecification
    {
        public class ProductcountSecification : BaseSecficiation<Product>
        {
            public ProductcountSecification(ProductQueryParameters parameters)
                : base(CreateCriteria(parameters))
            {
              
            }
          
            private static Expression<Func<Product, bool>> CreateCriteria
                    (ProductQueryParameters parameters)
            {
                return x =>
                    (!parameters.BrandId.HasValue || x.BrandID == parameters.BrandId) &&

                    (!parameters.TypeId.HasValue || x.TypeID == parameters.TypeId) &&
                     (string.IsNullOrWhiteSpace(parameters.Search) || x.Name.Contains(parameters.Search));
            }
        
}
}
