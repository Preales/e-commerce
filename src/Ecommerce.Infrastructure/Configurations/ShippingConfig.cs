using Ecommerce.Infrastructure.Configurations.Base;
using Ecommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Configurations
{
    public class ShippingConfig : BaseEntityConfig<Shipping>
    {
        public override void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.ClientId).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Country).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Department).HasMaxLength(100).IsRequired();
            builder.Property(p => p.City).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(254).IsRequired();
            base.Configure(builder);

            builder.HasOne(x => x.Client)
                .WithMany(o => o.Shippings)
                .HasForeignKey(f => f.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}