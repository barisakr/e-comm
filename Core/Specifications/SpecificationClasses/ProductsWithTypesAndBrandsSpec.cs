using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications.SpecificationClasses
{
    public class ProductsWithTypesAndBrandsSpec : BaseSpecification<Product>
    {
        
        public ProductsWithTypesAndBrandsSpec(ProductSpecificationParameters parameters)
            : base(x => 
            (string.IsNullOrEmpty(parameters.Search) || x.Name.ToLower().Contains
            (parameters.Search)) &&
            (!parameters.BrandId.HasValue || x.ProductBrandId == parameters.BrandId) &&
            (!parameters.TypeId.HasValue || x.ProductTypeId == parameters.TypeId)
            )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(parameters.PageSize * (parameters.PageIndex - 1), parameters.PageSize);

            if(!string.IsNullOrEmpty(parameters.Sort))
            {
                switch (parameters.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                      case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break; 
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}