using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Core.Models;
using ProductStore.DataAccess.Entites;

namespace ProductStore.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(Product.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(b => b.Description);

            builder.Property(b => b.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.HasOne<ProductCategoryEntity>()
                    .WithMany()
                    .HasForeignKey(i => i.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
