using Ecommerce.Infrastructure.Configurations.Base;
using Ecommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Configurations
{
    public class OrderConfig : BaseEntityConfig<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.ClientId).IsRequired().HasMaxLength(20);
            builder.Property(p => p.ShippingId).IsRequired();

            builder.Property(p => p.DiscountTotal).IsRequired().HasColumnType("numeric(18,2)");
            builder.Property(p => p.AmountTotal).IsRequired().HasColumnType("numeric(18,2)");

            base.Configure(builder);

            builder.HasOne(x => x.Client)
                .WithMany(o => o.Orders)
                .HasForeignKey(f => f.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Shipping)
                .WithOne(o => o.Order)
                .HasForeignKey<Order>(f => f.ShippingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}