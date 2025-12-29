using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class InventoryTransactionConfiguration : BaseEntityConfiguration<InventoryTransaction>
    {
        public override void Configure(EntityTypeBuilder<InventoryTransaction> builder)
        {
            base.Configure(builder);

            builder.ToTable("InventoryTransactions","Products");

            builder.HasOne(it => it.Product)
                .WithMany(p => p.InventoryTransactions)
                .HasForeignKey(it => it.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(it => it.TransactionType)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(it => it.Quantity)
                .HasPrecision(18, 3)
                .IsRequired();

            builder.Property(it => it.TransactionAt)
                .IsRequired();

            builder.Property(it => it.RelatedEntityId)
                .IsRequired(false);

            builder.Property(it => it.Notes)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.HasIndex(it => it.ProductId);
            builder.HasIndex(it => it.TransactionAt);
            builder.HasIndex(it => it.TransactionType);
        }
    }
}