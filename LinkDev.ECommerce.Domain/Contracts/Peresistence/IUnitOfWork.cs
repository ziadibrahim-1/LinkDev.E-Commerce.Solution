using LinkDev.ECommerce.Domain.Entity.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.Domain.Contracts.Peresistence
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<TEntity , TKey> GetRepository<TEntity , TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>;

        Task<int> CompleteAsync();


    }
}
