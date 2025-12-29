using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class PayrollRecordConfiguration : AuditableEntityConfiguration<PayrollRecord>
    {
        public override void Configure(EntityTypeBuilder<PayrollRecord> builder)
        {
            base.Configure(builder);

            builder.ToTable("PayrollRecords","HR");

            builder.Property(p => p.GrossSalary)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.Deductions)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Ignore(p => p.NetSalary);

            builder.Property(p => p.PeriodStart)
                .IsRequired();

            builder.Property(p => p.PeriodEnd)
                .IsRequired();

            builder.Property(p => p.PaidAt)
                .IsRequired();

            builder.Property(p => p.Notes)
                .HasMaxLength(1000);

            builder.HasOne(p => p.Employee)
                .WithMany(p => p.PayrollRecords)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.EmployeeId);
            builder.HasIndex(p => p.PaidAt);
            builder.HasIndex(p =>new {p.PeriodStart, p.PeriodEnd });
        }
    }
}
