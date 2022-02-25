using Ecommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            Random randon = new();

            var listClient = new List<Client>();
            var listProduct = new List<Product>();
            var listShipping = new List<Shipping>();

            for (int i = 1; i <= 3; i++)
            {
                listProduct.Add(new Product() { Id = i, Description = $"Product {i}", Price = i * randon.Next(1000,5000), Tax = randon.Next(0,20), CreationDate = new DateTime(2022, 02, 24) });
                listClient.Add(new Client() { Id = $"123456{i}", Name = $"Client {i}", LastName = $"LastName {i}", Telephone = $"123456{i}", Email = $"client_{i}@contoso.com", CreationDate = new DateTime(2022, 02, 24) });
                listShipping.Add(new Shipping() { Id =  Guid.NewGuid(), ClientId = $"123456{i}", Country = "CO", Department = $"Department {i}", City = $"City {i}", Address = $"Address {i}", CreationDate = new DateTime(2022, 02, 24) });
            }

            #region builder

            modelBuilder.Entity<Client>().HasData(listClient);
            modelBuilder.Entity<Product>().HasData(listProduct);
            modelBuilder.Entity<Shipping>().HasData(listShipping);

            #endregion
        }
    }
}