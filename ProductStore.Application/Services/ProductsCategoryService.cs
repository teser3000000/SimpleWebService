using ProductStore.Core.Abstractions;
using ProductStore.Core.Models;

namespace ProductStore.Application.Services
{
    public class ProductsCategoryService : IProductsCategoryService
    {
        private readonly IProductCategoryRepository _productsCategoryRepository;

        public ProductsCategoryService(IProductCategoryRepository productsCategoryRepository)
        {
            _productsCategoryRepository = productsCategoryRepository;
        }

        public async Task<List<ProductCategory>> GetAllProductCategory()
        {
            return await _productsCategoryRepository.Get();
        }

        public async Task<int> CreateProductCategory(ProductCategory productCategory)
        {
            return await _productsCategoryRepository.Create(productCategory);
        }

        public async Task<int> UpdateProductCategory(int id, string name, string description)
        {
            return await _productsCategoryRepository.Update(id, name, description);
        }

        public async Task<int> DeleteProductCategory(int id)
        {
            return await _productsCategoryRepository.Delete(id);
        }
    }


}
