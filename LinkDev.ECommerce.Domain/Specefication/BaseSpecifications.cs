using LinkDev.ECommerce.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.Domain.Specefication
{
    public class BaseSpecifications<TEntity, TKey> : ISpecification<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get ; set; }
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new ();

        public Expression<Func<TEntity, object>>? OrderBy { get; set; }
        public Expression<Func<TEntity, object>>? OrderByDesc { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 0;
        public bool IsPaginationEnabled { get; set; } = false;

        public BaseSpecifications()
        {
            
        }
        public BaseSpecifications(Expression<Func<TEntity,bool>> critiriaExpretion)
        {
            Criteria = critiriaExpretion;

        }

        public BaseSpecifications(TKey id)
        {
            Criteria = E => E.Id.Equals(id);
        }

        #region Helper Methouds

        private protected virtual void AddInclude()
        {
            
        }

        private protected virtual void AddSorting(string sort)
        {

        }

        private protected virtual void AddOrderBy(Expression<Func<TEntity, object>> orderBy)
        {
            OrderBy = orderBy;
        }

        private protected virtual void AddOrderByDesc(Expression<Func<TEntity, object>> orderByDesc)
        {
            OrderByDesc = orderByDesc;
        }

        private protected virtual void AddPagination(int skip , int take) 
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }
        #endregion
    }
}
