using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("Roles","ApplicationIdentity");

            builder.Property(r => r.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(r => r.Name)
                .HasMaxLength(256);

            builder.Property(r => r.NormalizedName)
                .HasMaxLength(256);
        }
    }
}
