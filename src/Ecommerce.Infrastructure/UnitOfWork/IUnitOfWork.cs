using Ecommerce.Infrastructure.Repository;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Save();
        Task<bool> SaveAsync();
        void Rollback();
        IRepository<TEntity> CreateRepository<TEntity>() where TEntity : class;
    }
}
