using ProductStore.Core.Models;

namespace ProductStore.Core.Abstractions
{
    public interface IProductsCategoryService
    {
        Task<int> CreateProductCategory(ProductCategory productCategory);
        Task<int> DeleteProductCategory(int id);
        Task<List<ProductCategory>> GetAllProductCategory();
        Task<int> UpdateProductCategory(int id, string name, string description);
    }
}