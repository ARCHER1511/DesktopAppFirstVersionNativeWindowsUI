using ERPAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAppInfrastructure.Configurations
{
    public class ProductImageConfiguration : BaseEntityConfiguration<ProductImage>
    {
        public override void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            base.Configure(builder);

            builder.ToTable("ProductImages", "Products");

            builder.Property(i => i.FileName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(i => i.URL)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(i => i.SortOrder)
                .IsRequired();

            builder.Property(i => i.IsMain)
                .HasDefaultValue(false);

            builder.HasOne(i => i.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(i => i.ProductId)
                .HasFilter("[IsMain] = 1")
                .IsUnique();

            builder.HasIndex(i => new {i.ProductId,i.SortOrder});
        }
    }
}
