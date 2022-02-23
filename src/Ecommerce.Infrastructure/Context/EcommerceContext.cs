using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Context
{
    public class EcommerceContext : DbContext, IContext
    {
        public EcommerceContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            //Desactivar la carga lenta de Entitie Framework
            ChangeTracker.LazyLoadingEnabled = false;
            //Desactivar consulta con seguimiento
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public int Save()
        {
            try
            {
                var count = SaveChanges();
                return count;
            }
            catch
            {
                Clear();
                throw;
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                var count = await SaveChangesAsync().ConfigureAwait(false);
                return count > 0;
            }
            catch
            {
                Clear();
                throw;
            }
        }

        public void Clear()
        {
            var clearables = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified ||
                    e.State == EntityState.Deleted).ToList();
            clearables.ForEach(x => x.State = EntityState.Detached);
            RollBack();
        }

        public void RollBack()
        {
            ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}