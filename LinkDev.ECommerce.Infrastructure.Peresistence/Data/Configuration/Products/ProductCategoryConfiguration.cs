using LinkDev.ECommerce.Domain.Entity.Products;
using LinkDev.ECommerce.Infrastructure.Persistence.Data.Configuration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.ECommerce.Infrastructure.Persistence.Data.Configuration.Products
{
    internal class ProductCategoryConfiguration : BaseAuditableEntityConfiguration<ProductCategory,int>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);
            builder.Property(category =>category.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
        
    }
}
