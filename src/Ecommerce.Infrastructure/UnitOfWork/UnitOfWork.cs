using Ecommerce.Infrastructure.Context;
using Ecommerce.Infrastructure.Repository;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Attributes
        private readonly IContext _context;
        private readonly IRepositoryFactory _repositoryFactory;
        private bool disposedValue;
        #endregion

        #region Constructor
        public UnitOfWork(IContext context, IRepositoryFactory repositoryFactory)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        public UnitOfWork()
        {
        }

        #endregion

        #region Methods

        public int Save() => _context.Save();

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveAsync().ConfigureAwait(false);
        }

        public void Clear() => _context.Clear();

        public void Rollback() => _context.RollBack();

        public IRepository<TEntity> CreateRepository<TEntity>() where TEntity : class
        {
            return _repositoryFactory.CreateRepository<TEntity>();
        }

        #endregion

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }

        ~UnitOfWork()
            => Dispose(disposing: false);


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}