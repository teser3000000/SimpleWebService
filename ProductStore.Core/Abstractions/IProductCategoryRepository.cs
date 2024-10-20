using ProductStore.Core.Models;

namespace ProductStore.Core.Abstractions
{
    public interface IProductCategoryRepository
    {
        Task<int> Create(ProductCategory product);
        Task<int> Delete(int id);
        Task<List<ProductCategory>> Get();
        Task<int> Update(int id, string name, string description);
    }
}