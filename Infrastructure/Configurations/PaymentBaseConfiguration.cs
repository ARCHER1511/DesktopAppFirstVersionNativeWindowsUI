using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public abstract class PaymentBaseConfiguration<T> : AuditableEntityConfiguration<T> where T :PaymentBase
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Amount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.PaymentDate)
                .IsRequired();

            builder.Property(p => p.Method)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Reference)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.HasIndex(p => p.PaymentDate);
            builder.HasIndex(p => p.Method);
        }
    }
}
