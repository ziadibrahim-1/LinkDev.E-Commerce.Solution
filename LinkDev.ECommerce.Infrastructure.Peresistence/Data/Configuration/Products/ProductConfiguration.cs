using LinkDev.ECommerce.Domain.Entity.Products;
using LinkDev.ECommerce.Infrastructure.Persistence.Data.Configuration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.ECommerce.Infrastructure.Persistence.Data.Configuration.Products
{
    internal class ProductConfiguration : BaseAuditableEntityConfiguration<Product, int>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(9,2)");

            // Configure the relationship between Product and ProductBrand
            builder.HasOne(p => p.ProductBrand)
                .WithMany()
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure the relationship between Product and ProductCategory
            builder.HasOne(p => p.ProductCategory)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
