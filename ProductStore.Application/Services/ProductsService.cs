using ProductStore.Core.Abstractions;
using ProductStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productsRepository.Get();
        }

        public async Task<int> CreateProduct(Product product)
        {
            return await _productsRepository.Create(product);
        }

        public async Task<int> UpdateProduct(int id, string name, string description, decimal price, int categoryId)
        {
            return await _productsRepository.Update(id, name, description, price, categoryId);
        }

        public async Task<int> DeleteProduct(int id)
        {
            return await _productsRepository.Delete(id);
        }
    }


}
