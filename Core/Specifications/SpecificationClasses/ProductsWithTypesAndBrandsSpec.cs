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
        public ProductsWithTypesAndBrandsSpec()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public ProductsWithTypesAndBrandsSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}