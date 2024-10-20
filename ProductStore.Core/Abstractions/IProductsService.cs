using ProductStore.Core.Models;

namespace ProductStore.Core.Abstractions
{
    public interface IProductsService
    {
        Task<int> CreateProduct(Product product);
        Task<int> DeleteProduct(int id);
        Task<List<Product>> GetAllProducts();
        Task<int> UpdateProduct(int id, string name, string description, decimal price, int categoryId);
    }
}