using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.ECommerce.Infrastructure.Persistence.Data.Configuration.Base
{
    internal class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
