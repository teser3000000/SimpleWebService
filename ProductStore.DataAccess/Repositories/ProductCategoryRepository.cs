using Microsoft.EntityFrameworkCore;
using ProductStore.Core.Abstractions;
using ProductStore.Core.Models;
using ProductStore.DataAccess.Entites;

namespace ProductStore.DataAccess.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ProductStoreDbContext _context;

        public ProductCategoryRepository(ProductStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCategory>> Get()
        {
            var productsCategoryEntities = await _context.ProductCategories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();

            Console.WriteLine("Retrieved categories: " + productsCategoryEntities.Count);

            var productsCategory = productsCategoryEntities
                .Select(b => new ProductCategory(b.Id, b.Name, b.Description))
                .ToList();

            return productsCategory;
        }

        public async Task<int> Create(ProductCategory product)
        {
            var productsCategoryEntity = new ProductCategoryEntity
            {
                Name = product.Name,
                Description = product.Description
            };

            await _context.ProductCategories.AddAsync(productsCategoryEntity);
            await _context.SaveChangesAsync();

            product.Id = productsCategoryEntity.Id;

            return product.Id;
        }

        public async Task<int> Update(int id, string name, string description)
        {
            await _context.ProductCategories
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Description, b => description)
                );

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<int> Delete(int id)
        {
            await _context.ProductCategories
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
