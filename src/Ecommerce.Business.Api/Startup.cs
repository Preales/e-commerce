using Ecommerce.Business.Api.Filters;
using Ecommerce.Business.Api.Validators;
using Ecommerce.Infrastructure.Context;
using Ecommerce.Infrastructure.Extensions;
using Ecommerce.Infrastructure.Repository;
using Ecommerce.Infrastructure.UnitOfWork;
using Ecommerce.Service.Interfaces;
using Ecommerce.Service.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace Ecommerce.Business.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<ILogger, Logger<EcommerceContext>>();

            services.AddDatabaseContext<EcommerceContext>(Configuration)
                .AddScoped<IContext>(provider => provider.GetService<EcommerceContext>());

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IShippingService, ShippingService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"v1",
                   new OpenApiInfo
                   {
                       Title = $"Ecommerce.Business.Api",
                       Version = $"{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")} - v{Assembly.GetExecutingAssembly().GetName().Version}",
                       Description = "Design a DDD (Domain-Driven Design), .NET Core 5.0",
                       Contact = new OpenApiContact
                       {
                           Name = "Priscy Antonio Reales Mozo",
                           Email = "realespriscy@hotmail.com"
                       }
                   });
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductModelValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce.Business.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
