using LinkDev.ECommerce.Domain.Entity.Products;
using LinkDev.ECommerce.Infrastructure.Persistence.Data.Configuration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.ECommerce.Infrastructure.Persistence.Data.Configuration.Products
{
    internal class ProductBrandConfiguration : BaseAuditableEntityConfiguration<ProductBrand,int>
    {
        public override void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            base.Configure(builder);
            builder.Property(brand => brand.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
