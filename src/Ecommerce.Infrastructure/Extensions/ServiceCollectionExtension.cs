using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ecommerce.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseContext<T>(this IServiceCollection services, IConfiguration config) where T : DbContext
        {
            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(
                    config.GetConnectionString("Connection"),
                    optsql =>
                    {
                        optsql.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
                        optsql.MigrationsAssembly(typeof(T).Assembly.FullName);
                    });
            });
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            dbContext.Database.Migrate();
            return services;
        }
    }
}