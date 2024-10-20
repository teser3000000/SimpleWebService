using Microsoft.EntityFrameworkCore;
using ProductStore.Core.Models;
using ProductStore.DataAccess.Configurations;
using ProductStore.DataAccess.Entites;

namespace ProductStore.DataAccess
{
    public class ProductStoreDbContext : DbContext
    {
        public ProductStoreDbContext(DbContextOptions<ProductStoreDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
