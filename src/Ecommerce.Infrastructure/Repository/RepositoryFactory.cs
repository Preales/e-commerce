using Ecommerce.Infrastructure.Context;

namespace Ecommerce.Infrastructure.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IContext _context;

        public RepositoryFactory(IContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> CreateRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }
    }
}