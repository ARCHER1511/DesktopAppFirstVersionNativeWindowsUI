using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users", "ApplicationIdentity");

            builder.Property(u => u.FullName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.UserName)
                .HasMaxLength(256);

            builder.Property(u => u.NormalizedUserName)
                .HasMaxLength(256);

            builder.Property(u => u.Email)
                .HasMaxLength(256);

            builder.Property(u => u.NormalizedEmail)
                .HasMaxLength(256);
        }
    }
}
