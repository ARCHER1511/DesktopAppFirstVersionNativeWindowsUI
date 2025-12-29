using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class SupplierConfiguration : AuditableEntityConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            base.Configure(builder);

            builder.ToTable("Suppliers", "Core");

            builder.Property(s => s.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(s => s.ContractName)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(s => s.Phone)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Email)
                .HasMaxLength(320)
                .IsRequired();

            builder.Property(s => s.IsActive)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasMany(s => s.PurchaseOrders)
                  .WithOne(po => po.Supplier)
                  .HasForeignKey(po => po.SupplierId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.PurchasePayments)
                  .WithOne(pp => pp.Supplier)
                  .HasForeignKey(pp => pp.SupplierId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Products)
                  .WithOne(p => p.Supplier)
                  .HasForeignKey(p => p.SupplierId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => s.Name);
            builder.HasIndex(s => s.Email);
            builder.HasIndex(s => new { s.IsActive, s.Name });

        }
    }
}
