using LinkDev.ECommerce.Domain.Contracts;
 
namespace LinkDev.ECommerce.Infrastructure.Persistence.Repositories.GenericRepository
{
    internal static class SpecificationsEvaluator<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public static IQueryable<TEntity> GetEntitie(IQueryable<TEntity> inputQuery, ISpecification<TEntity, TKey> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);
            else if (spec.OrderByDesc != null)
                query = query.OrderByDescending(spec.OrderByDesc);

            if (spec.IsPaginationEnabled)
                query = query.Skip(spec.Skip).Take(spec.Take);

            query = spec.Includes.Aggregate(query, (CurrentQuery, IncludeExprestion) => CurrentQuery.Include(IncludeExprestion));
            return query;
        }
    }
}
