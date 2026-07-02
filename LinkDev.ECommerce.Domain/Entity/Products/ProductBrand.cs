namespace LinkDev.ECommerce.Domain.Entity.Products
{
    public class ProductBrand : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
    }
}
