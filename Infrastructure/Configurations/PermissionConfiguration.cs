using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class PermissionConfiguration : BaseEntityConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            builder.ToTable("Permissions", "Security");

            builder.Property(p => p.Code)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(p => p.Code)
                .IsUnique();

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.HasMany(p => p.RolePermissions)
                .WithOne(rp => rp.Permission)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
