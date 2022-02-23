using Ecommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ecommerce.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection EcommerceInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<IContext, EcommerceContext>(options =>
            {
                ///options.UseSqlite(config.GetConnectionString("Connection"));
                options.UseSqlServer(
                    config.GetConnectionString("Connection"),
                    optsql => optsql.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds));
            });

            return services;
        }
    }
}