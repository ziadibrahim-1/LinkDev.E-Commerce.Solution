using LinkDev.ECommerce.Domain.Entity.Products;

namespace LinkDev.ECommerce.Domain.Specefication.Products
{
    public class ProductForCountSpecefications : BaseSpecifications<Product,int>
    {
        public ProductForCountSpecefications(int? brandId , int? CategoryId , string? search)
            :base(
                 p=> 
                 
                 (string.IsNullOrEmpty(search) || p.NormalizedName.Contains(search))
                 &&
                 (!brandId.HasValue || p.BrandId == brandId.Value)

                 &&

                 (!CategoryId.HasValue || p.CategoryId == CategoryId.Value)
                 )
        {
            
        }

    }
}
