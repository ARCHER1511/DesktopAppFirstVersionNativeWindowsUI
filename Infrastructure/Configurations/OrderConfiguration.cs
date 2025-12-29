using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class OrderConfiguration : AuditableEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("Orders","Orders");

            builder.Property(o => o.Number)
                .HasMaxLength(50)
                .IsRequired();
            builder.HasIndex(o => o.Number)
                .IsUnique();

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(o => o.CreatedByUser)
                .WithMany()
                .HasForeignKey( o => o.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property( o => o.SubTotal)
                .HasPrecision(18,2)
                .IsRequired();

            builder.Property( o => o.Tax)
                .HasPrecision(18,2)
                .IsRequired();
            builder.Property( o => o.Discount)
                .HasPrecision(18,2)
                .IsRequired();
            builder.Property(o => o.Status)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasMany( o => o.Items)
                .WithOne( i => i.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.Payments)
                .WithOne( i => i.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(o => o.OrderDate);
            builder.HasIndex(o => o.Status);
        }
    }
}
