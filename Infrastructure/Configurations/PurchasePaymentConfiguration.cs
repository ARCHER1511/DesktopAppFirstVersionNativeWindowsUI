using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class PurchasePaymentConfiguration : AuditableEntityConfiguration<PurchasePayment>
    {
        public override void Configure(EntityTypeBuilder<PurchasePayment> builder)
        {
            base.Configure(builder);

            builder.ToTable("PurchasePayments", "Payments");

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

            builder.HasOne(p => p.PurchaseOrder)
                .WithMany(po => po.Payments)
                .HasForeignKey(p => p.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Supplier)
                .WithMany(s => s.PurchasePayments)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.PurchaseOrderId);
            builder.HasIndex(p => p.SupplierId);
            builder.HasIndex(p => p.PaymentDate);

        }
    }
}
