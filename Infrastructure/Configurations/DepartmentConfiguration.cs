using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class DepartmentConfiguration : BaseEntityConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            base.Configure(builder);

            builder.ToTable("Depatments","Core");

            builder.Property(d => d.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(d => d.Name)
                .IsUnique();

            builder.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
