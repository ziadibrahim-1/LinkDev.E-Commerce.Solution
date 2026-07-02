namespace LinkDev.ECommerce.Domain.Entity.Products
{
    public class ProductCategory : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
    }
}
