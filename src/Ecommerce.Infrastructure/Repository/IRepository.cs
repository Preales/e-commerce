using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> AsQueryable();

        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> GetAllAsync(
            int page,
            int limit,
            string orderBy,
            bool ascending = true);

        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> where,
            int page,
            int limit,
            string orderBy,
            bool ascending = true);

        //Task<TEntity> FirstOrDefaultAsync(
        //    Expression<Func<TEntity, bool>> where,
        //    params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);

        Task<TEntity> LastOrDefaultAsync(
            Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includeProperties);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(object id);

        void Delete(IEnumerable<TEntity> entities);
    }
}