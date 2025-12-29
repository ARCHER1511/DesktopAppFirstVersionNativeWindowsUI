using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class EmployeeConfiguration : AuditableEntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.ToTable("Employees", "Core");

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();

            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();

            builder.Property(e => e.JobTitle).HasMaxLength(100).IsRequired();

            builder.HasIndex(e => new { e.FirstName, e.LastName });

            builder
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.PayrollRecords)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Employee>(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
