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
    public class ProductWithTypeAndSepecification : BaseSecficiation<Product>
    {
        public ProductWithTypeAndSepecification(ProductQueryParameters parameters)
            : base(CreateCriteria(parameters))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
            switch (parameters.Sort)
            {
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDesc(x=>x.Price);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(x => x.Price);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDesc(x => x.Name);
                    break;
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(x => x.Name);
                    break;
                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
            ApplyPagination(parameters.PageSize, parameters.PageIndex);
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

                (!parameters.TypeId.HasValue || x.TypeID == parameters.TypeId)&&
                 (string.IsNullOrWhiteSpace(parameters.Search)|| x.Name.Contains(parameters.Search));
        }
    }
    }
