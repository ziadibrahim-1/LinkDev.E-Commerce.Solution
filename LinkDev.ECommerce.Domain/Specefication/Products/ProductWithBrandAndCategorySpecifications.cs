using LinkDev.ECommerce.Domain.Entity.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.Domain.Specefication.Products
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndCategorySpecifications(string? sort ,int? brandId, int? categoryId, int pageIndex, int pageSize , string? search)
            : base(p =>
                    (string.IsNullOrEmpty(search) || p.NormalizedName.Contains(search))
                    &&
                    (!brandId.HasValue || p.BrandId == brandId.Value)
                    &&
                    (!categoryId.HasValue || p.CategoryId == categoryId.Value)
                    
            )
        {

            AddInclude();
            AddSorting(sort);
            AddPagination((pageIndex - 1) * pageSize, pageSize);
        }

        private protected override void AddSorting(string? sort)
        {
            switch (sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }

        public ProductWithBrandAndCategorySpecifications(int id)
                : base(id)
        {
            AddInclude();
        }

        

        private protected override void AddInclude()
        {
            base.AddInclude();
            Includes.Add(p => p.ProductBrand!);
            Includes.Add(p => p.ProductCategory!);
        }
    }
}
