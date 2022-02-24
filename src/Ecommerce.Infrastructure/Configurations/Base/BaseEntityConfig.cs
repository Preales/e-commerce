using Ecommerce.Infrastructure.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Configurations.Base
{
    public class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreationDate)
                .HasColumnType("datetime");

            builder.Property(e => e.ModificationDate)
                .HasColumnType("datetime");

            builder.Property(e => e.Deleted)
                .IsUnicode(false);
        }
    }
}