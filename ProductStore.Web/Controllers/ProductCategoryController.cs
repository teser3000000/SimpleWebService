using Microsoft.AspNetCore.Mvc;
using ProductStore.Core.Abstractions;
using ProductStore.Core.Models;
using ProductStore.Web.Contracts;
using Task.Contracts;

namespace ProductStore.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductsCategoryService _productsCategoryService;

        public ProductCategoryController(IProductsCategoryService productsCategoryService)
        {
            _productsCategoryService = productsCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsCategoryResponse>>> GetProductsCategory()
        {
            var productsCategories = await _productsCategoryService.GetAllProductCategory();

            if (productsCategories == null || productsCategories.Count == 0)
            {
                return NotFound("No categories found.");
            }

            var response = productsCategories.Select(b =>
                new ProductsCategoryResponse(b.Id, b.Name, b.Description ?? string.Empty)
            ).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProductCategory([FromForm] ProductsCategoryRequest productsCategoryRequest)
        {
            var productCategory = new ProductCategory(
                productsCategoryRequest.Name,
                productsCategoryRequest.Description
                );

            var productId = await _productsCategoryService.CreateProductCategory(productCategory);

            return Ok($"Success! id = {productId}");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateProductCategory(int id, [FromForm] ProductsCategoryRequest productsRequest)
        {
            var productId = await _productsCategoryService.UpdateProductCategory(id,
                productsRequest.Name,
                productsRequest.Description
                );

            return Ok($"Success!");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteProductCategory(int id)
        {
            return Ok(await _productsCategoryService.DeleteProductCategory(id));
        }
    }
}
