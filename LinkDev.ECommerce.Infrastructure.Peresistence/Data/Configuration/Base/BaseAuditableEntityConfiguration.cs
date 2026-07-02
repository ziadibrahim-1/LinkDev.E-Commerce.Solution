using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.ECommerce.Infrastructure.Persistence.Data.Configuration.Base
{
    internal class BaseAuditableEntityConfiguration<TEntity ,TKey> : BaseEntityConfiguration<TEntity ,TKey>
        where TEntity : BaseAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);


            //builder.Property(b => b.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
            //builder.Property(b => b.LastModifiedOn).HasComputedColumnSql("GETUTCDATE()");
        }
    }
}
