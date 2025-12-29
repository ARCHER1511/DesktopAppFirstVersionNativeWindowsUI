using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class SalePaymentConfiguration : AuditableEntityConfiguration<SalePayment>
    {
        public override void Configure(EntityTypeBuilder<SalePayment> builder)
        {
            base.Configure(builder);

            builder.ToTable("SalePayments", "Payments");

            builder.Property(p => p.Amount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.Method)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Reference)
                .HasMaxLength(150);

            builder.Property(p => p.PaymentDate)
                .IsRequired();

            builder.HasOne(p => p.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ElectronicPayment)
                .WithMany()
                .HasForeignKey(p => p.ElectronicPaymentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.OrderId);
            builder.HasIndex(p => p.CustomerId);
            builder.HasIndex(p => p.PaymentDate);
        }
    }
}
