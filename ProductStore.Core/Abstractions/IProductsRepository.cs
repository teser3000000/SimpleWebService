using ProductStore.Core.Models;

namespace ProductStore.Core.Abstractions
{
    public interface IProductsRepository
    {
        Task<int> Create(Product product);
        Task<int> Delete(int id);
        Task<List<Product>> Get();
        Task<int> Update(int id, string name, string description, decimal price, int categoryId);
    }
}