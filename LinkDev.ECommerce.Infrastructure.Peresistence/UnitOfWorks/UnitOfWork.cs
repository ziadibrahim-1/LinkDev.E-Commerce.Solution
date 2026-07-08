using LinkDev.ECommerce.Domain.Contracts;
using LinkDev.ECommerce.Infrastructure.Peresistence.Data;
using LinkDev.ECommerce.Infrastructure.Persistence.Repositories;
using System.Collections.Concurrent;

namespace LinkDev.ECommerce.Infrastructure.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _dbContext;
        private readonly ConcurrentDictionary<string, object> _repositories;


        public UnitOfWork(StoreContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new ConcurrentDictionary<string, object>();

        }
        
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {

            return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(_dbContext));

        }

        public async Task<int> CompleteAsync() => await _dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
        

    }
}
