namespace LinkDev.ECommerce.Domain.Entity.Products
{
    public class Product : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
        public required string NormalizedName { get; set; }
        public required string Description { get; set; }
        public  decimal Price { get; set; }
        public  string? PictureUrl { get; set; }
        // Navigation properties
        public  int? BrandId { get; set; } // Foreign key for ProductBrand
        public virtual ProductBrand? ProductBrand { get; set; }
        public  int? CategoryId { get; set; } // Foreign key for ProductCategory
        public virtual ProductCategory? ProductCategory { get; set; }
    }
}
