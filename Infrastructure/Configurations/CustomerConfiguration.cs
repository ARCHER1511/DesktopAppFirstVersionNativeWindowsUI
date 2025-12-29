using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class CustomerConfiguration : AuditableEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "Core");

            builder.Property(c => c.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.HasOne(c => c.RecordedByUser)
                .WithMany()
                .HasForeignKey(c => c.RecordedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
