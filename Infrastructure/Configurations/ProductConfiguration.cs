using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class ProductConfiguration : AuditableEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("Products", "Products");

            builder.Property(p => p.SKU)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(p => p.SKU)
                .IsUnique();

            builder.Property(p => p.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.ShortDescription)
                .HasMaxLength(500);

            builder.Property(p => p.LongDescription)
                .HasMaxLength(4000);

            builder.Property(p => p.CostPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.SalePrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.QuantityInStock)
                .IsRequired();

            builder.HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.MainImage)
                .WithMany()
                .HasForeignKey(p => p.MainImageId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PurchaseOrderItems)
                .WithOne(poi => poi.Product)
                .HasForeignKey(poi => poi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.InventoryTransactions)
                .WithOne(it => it.Product)
                .HasForeignKey(it => it.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.Name);
            builder.HasIndex(p => p.SupplierId);
        }
    }
}
