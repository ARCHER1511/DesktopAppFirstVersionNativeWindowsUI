using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class ElectronicPaymentConfiguration : BaseEntityConfiguration<ElectronicPayment>
    {
        public override void Configure(EntityTypeBuilder<ElectronicPayment> builder)
        {
            base.Configure(builder);

            builder.ToTable("ElectronicPayments", "Payments");

            builder.Property(e => e.ExternalTransactionId)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Provider)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Amount)
                .HasPrecision(18,2)
                .IsRequired();

            builder.Property(e => e.OccurredAt)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Payload)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.HasIndex(e => e.ExternalTransactionId)
                .IsUnique();

            builder.HasIndex(e => e.OccurredAt);
            builder.HasIndex(e => e.Provider);
            builder.HasIndex(e => e.Status);
        }
    }
}
