using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public abstract class AuditableEntityConfiguration<T> : BaseEntityConfiguration<T> where T: AuditableEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired(false);

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(e => e.CreatedById)
                .IsRequired(false);

            builder.Property(e => e.UpdatedById)
                .IsRequired(false);

            builder.HasIndex(e => e.IsDeleted);
        }
    }
}
