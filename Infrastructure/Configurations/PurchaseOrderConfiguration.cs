using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class PurchaseOrderConfiguration : AuditableEntityConfiguration<PurchaseOrder>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            base.Configure(builder);

            builder.ToTable("PurchaseOrders", "Orders");

            builder.Property(po => po.Number)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(po => po.Number)
                .IsUnique();

            builder.HasOne(po => po.Supplier)
                .WithMany(s => s.PurchaseOrders)
                .HasForeignKey(po => po.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(po => po.OrderDate)
                .IsRequired();

            builder.Property(po => po.SubTotal)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Ignore(po => po.TotalCost);

            builder.Property(po => po.Status)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(po => po.Items)
                   .WithOne(i => i.PurchaseOrder)
                   .HasForeignKey(i => i.PurchaseOrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(po => po.Payments)
                .WithOne(pp => pp.PurchaseOrder)
                .HasForeignKey(pp => pp.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(po => po.SupplierId);
            builder.HasIndex(po => po.OrderDate);
        }
    }
}
