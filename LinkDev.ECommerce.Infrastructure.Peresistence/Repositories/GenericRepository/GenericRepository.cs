using LinkDev.ECommerce.Domain.Contracts;
using LinkDev.ECommerce.Domain.Contracts.Peresistence;
using LinkDev.ECommerce.Domain.Entity.Products;
using LinkDev.ECommerce.Infrastructure.Peresistence.Data;

namespace LinkDev.ECommerce.Infrastructure.Persistence.Repositories.GenericRepository
{
    internal class GenericRepository<TEntity, TKey>(StoreContext _storeContext) : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return withTracking ?
                (IEnumerable<TEntity>) await  _storeContext.Set<Product>().Include(P => P.ProductBrand).Include(P => P.ProductCategory).ToListAsync() :
                (IEnumerable<TEntity>)await _storeContext.Set<Product>().Include(P => P.ProductBrand).Include(P => P.ProductCategory).AsNoTracking().ToListAsync();
            }

            return withTracking ? await _storeContext.Set<TEntity>().ToListAsync() :
            await _storeContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }
            
        
        public async Task<IEnumerable<TEntity>> GetAllWithSpcesAsync(ISpecification<TEntity, TKey> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }


        public async Task<TEntity?> GetAsync(TKey id) => await _storeContext.Set<TEntity>().FindAsync(id);

        public async Task<TEntity?> GetWithSpcesAsync(ISpecification<TEntity, TKey> spec)
        {
            return await ApplySpecification(spec).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity, TKey> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        public async Task AddAsync(TEntity entity) => await _storeContext.Set<TEntity>().AddAsync(entity);
        

        public void Update(TEntity entity) => _storeContext.Set<TEntity>().Update(entity);
         
        public void Delete(TEntity entity) => _storeContext.Set<TEntity>().Remove(entity);

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity, TKey> spec)
        {
            return SpecificationsEvaluator<TEntity, TKey>.GetEntitie(_storeContext.Set<TEntity>(), spec);
        }

        
    }
}
