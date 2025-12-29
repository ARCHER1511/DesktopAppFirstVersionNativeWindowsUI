using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class WalletConfiguration : BaseEntityConfiguration<Wallet>
    {
        public override void Configure(EntityTypeBuilder<Wallet> builder)
        {
            base.Configure(builder);

            builder.ToTable("Wallets", "Payments");

            builder.Property(w => w.OwnerUserId)
                   .IsRequired();

            builder.HasIndex(w => w.OwnerUserId)
                   .IsUnique();

            builder.Property(w => w.Balance)
                   .HasPrecision(18, 2)
                   .HasDefaultValue(0);

            builder.HasMany(w => w.Transactions)
                   .WithOne(t => t.Wallet)
                   .HasForeignKey(t => t.WalletId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
