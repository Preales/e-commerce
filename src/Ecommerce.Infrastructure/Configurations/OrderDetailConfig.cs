using Ecommerce.Infrastructure.Configurations.Base;
using Ecommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Configurations
{
    public class OrderDetailConfig : BaseEntityConfig<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.OrderId).IsRequired().HasMaxLength(20);
            builder.Property(p => p.ProductId).IsRequired();

            builder.Property(p => p.Price).IsRequired().HasColumnType("numeric(18,2)");
            builder.Property(p => p.Tax).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Discount).IsRequired().HasColumnType("numeric(18,2)");
            builder.Property(p => p.Amount).IsRequired().HasColumnType("numeric(18,2)");

            base.Configure(builder);

            builder.HasOne(x => x.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(f => f.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(f => f.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}