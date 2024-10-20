
using Microsoft.AspNetCore.Mvc;
using ProductStore.Core.Abstractions;
using ProductStore.Core.Models;
using ProductStore.Web.Contracts;
using Task.Contracts;

namespace ProductStore.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsResponse>>> GetProducts()
        {
            var products = await _productsService.GetAllProducts();

            var response = products.Select(b => new ProductsResponse(b.Id, b.Name, b.Description, b.Price, b.CategoryId));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct([FromForm] ProductsRequest productsRequest)
        {
            var product = new Product(
                productsRequest.Name,
                productsRequest.Description,
                productsRequest.Price,
                productsRequest.CategoryId);

            var productId = await _productsService.CreateProduct(product);

            return Ok($"Success! id = {productId}");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateProduct(int id, [FromForm] ProductsRequest productsRequest)
        {
            var productId = await _productsService.UpdateProduct(id,
                productsRequest.Name,
                productsRequest.Description,
                productsRequest.Price,
                productsRequest.CategoryId);

            return Ok($"Success!");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteProduct(int id)
        {
            return Ok(await _productsService.DeleteProduct(id));
        }
    }
}
