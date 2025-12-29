using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class WalletTransactionConfiguration : BaseEntityConfiguration<WalletTransaction>
    {
        public override void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            base.Configure(builder);

            builder.ToTable("WalletTransactions","Payments");

            builder.Property(t => t.WalletId)
                   .IsRequired();

            builder.HasIndex(t => t.WalletId);

            builder.Property(t => t.Amount)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(t => t.type)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(t => t.Reference)
                   .HasMaxLength(200);

            builder.Property(t => t.At)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(t => t.Wallet)
                   .WithMany(w => w.Transactions)
                   .HasForeignKey(t => t.WalletId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
