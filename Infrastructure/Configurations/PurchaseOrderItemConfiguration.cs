using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class PurchaseOrderItemConfiguration : BaseEntityConfiguration<PurchaseOrderItem>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("PurchaseOrderItems", "Orders");

            builder.Property(poi => poi.Quantity)
                .IsRequired();

            builder.Property(poi => poi.CostPrice)
                .HasPrecision(18,2)
                .IsRequired();

            builder.Ignore(poi => poi.LineTotal);

            builder.HasOne(poi => poi.PurchaseOrder)
                .WithMany(po => po.Items)
                .HasForeignKey(poi => poi.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(poi => poi.Product)
                .WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(poi => poi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(poi => poi.PurchaseOrderId);
            builder.HasIndex(poi => poi.ProductId);

            builder.HasIndex(poi => new { poi.PurchaseOrderId, poi.ProductId }).IsUnique();
        }
    }
}
