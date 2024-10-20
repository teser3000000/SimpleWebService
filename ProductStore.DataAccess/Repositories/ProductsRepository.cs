using Microsoft.EntityFrameworkCore;
using ProductStore.Core.Abstractions;
using ProductStore.Core.Models;
using ProductStore.DataAccess.Entites;

namespace ProductStore.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductStoreDbContext _context;
        public ProductsRepository(ProductStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Get()
        {
            var productsEntities = await _context.Products
                .AsNoTracking()
                .ToListAsync();

            var products = productsEntities
                .Select(b => new Product(b.Id, b.Name, b.Description, b.Price, b.CategoryId))
                .ToList();

            return products;
        }

        public async Task<int> Create(Product product)
        {
            var productEntity = new ProductEntity
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            product.Id = productEntity.Id;

            return product.Id;
        }


        public async Task<int> Update(int id, string name, string description, decimal price, int categoryId)
        {
            await _context.Products
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Price, b => price)
                .SetProperty(b => b.CategoryId, b => categoryId)
                );

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<int> Delete(int id)
        {
            await _context.Products
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
