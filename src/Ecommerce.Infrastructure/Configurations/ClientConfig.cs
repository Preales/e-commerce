using Ecommerce.Infrastructure.Configurations.Base;
using Ecommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Configurations
{
    public class ClientConfig : BaseEntityConfig<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Id).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Telephone).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(254).IsRequired();
            base.Configure(builder);

            builder.HasMany(x => x.Shippings)
                .WithOne(o => o.Client)
                .HasForeignKey(f => f.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Orders)
                .WithOne(o => o.Client)
                .HasForeignKey(f => f.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}