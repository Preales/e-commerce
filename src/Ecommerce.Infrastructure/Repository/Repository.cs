using Ecommerce.Infrastructure.Context;
using Ecommerce.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IContext _dataContext;
        private readonly DbSet<TEntity> _entities;

        public Repository(IContext dbcontext)
        {
            _dataContext = dbcontext;
            _entities = dbcontext.Set<TEntity>();
        }

        // Include lambda expressions in queries
        private IQueryable<TEntity> PerformInclusions(
            IEnumerable<Expression<Func<TEntity, object>>> includeProperties,
            IQueryable<TEntity> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #region IRepository<TEntity> Members

#pragma warning disable 1998
        public async Task<IQueryable<TEntity>> AsQueryable()
        {
            return _entities.AsQueryable();
        }
#pragma warning disable 1998

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            int page,
            int limit,
            string orderBy,
            bool ascending = true)
        {
            var result = await PagedResult<TEntity>.ToPagedListAsync(_entities.AsQueryable(), page, limit, orderBy, ascending);
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> where,
            int page,
            int limit,
            string orderBy,
            bool ascending = true)
        {
            return await PagedResult<TEntity>.ToPagedListAsync(_entities.AsQueryable().Where(where), page, limit, orderBy, ascending);
        }

        public async Task<TEntity> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }

        public async Task<TEntity> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = await AsQueryable();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }
            else
            {
                return await query.FirstOrDefaultAsync();
            }
        }

        public async Task<TEntity> LastOrDefaultAsync(
            Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.LastOrDefault(where);
        }

        public virtual void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dataContext.Entry(e).State = EntityState.Added;
            }
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dataContext.Entry(e).State = EntityState.Modified;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            if (_dataContext.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _entities.Find(id);
            _entities.Remove(entityToDelete);
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dataContext.Entry(e).State = EntityState.Deleted;
            }
        }

        #endregion IRepository<TEntity> Members
    }
}