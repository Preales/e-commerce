using Ecommerce.Infrastructure.Configurations.Base;
using Ecommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Configurations
{
    public class ProductConfig : BaseEntityConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Description).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Price).IsRequired().HasColumnType("numeric(18,2)");
            builder.Property(p => p.Tax).IsRequired();
            base.Configure(builder);
        }
    }
}