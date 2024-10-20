using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Core.Models;
using ProductStore.DataAccess.Entites;

namespace ProductStore.DataAccess.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(Product.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(b => b.Description);

            builder.HasMany<ProductEntity>()
                    .WithOne()
                    .HasForeignKey(p => p.CategoryId);

        }
    }
}
