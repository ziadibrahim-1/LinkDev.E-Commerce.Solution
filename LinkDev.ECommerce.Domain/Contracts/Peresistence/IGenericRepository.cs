using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.Domain.Contracts.Peresistence
{
    public interface IGenericRepository<TEntity,TKey> 
        where TEntity: BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false);
        Task<IEnumerable<TEntity>>GetAllWithSpcesAsync(ISpecification<TEntity,TKey> spec);
        Task<TEntity?> GetAsync(TKey id);
        Task<TEntity?> GetWithSpcesAsync(ISpecification<TEntity,TKey> spec);
        Task<int> CountAsync(ISpecification<TEntity,TKey> spec);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
