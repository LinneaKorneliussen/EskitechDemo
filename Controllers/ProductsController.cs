using Microsoft.AspNetCore.Mvc;
using EskitechDemo.Models;
using EskitechDemo.Services;
using EskitechDemo.DTOs;

namespace EskitechDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        #region HTTP Get Methods
        [HttpGet("products-with-inventory")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsWithInventory()
        {
            var allProducts = await _service.GetAllProductsWithInventory();

            if (allProducts == null || !allProducts.Any())
            {
                return NotFound(new { Message = "No products found." });
            }

            return Ok(allProducts);
        }

        [HttpGet("by-article/{articleNumber}")]
        public async Task<ActionResult<ProductDTO>> GetProductByArtNr(string articleNumber)
        {
            var product = await _service.GetProductByArtNr(articleNumber);

            if (product == null)
            {
                return NotFound(new { Message = "Product not found." });
            }

            return Ok(product);
        }

        [HttpGet("by-category/{category}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByCategory(ProductCategory category)
        {
            var productsByCategory = await _service.GetProductsByCategory(category);

            if (productsByCategory == null || !productsByCategory.Any())
            {
                return NotFound(new { Message = "No products found in this category." });
            }

            return Ok(productsByCategory);
        }
        #endregion

        #region HTTP Update Methods
        [HttpPut("update-inventory/{articleNumber}/{location}/{newQuantity}")] 
        public async Task<ActionResult> UpdateInventory(string articleNumber, string location, int newQuantity)
        {
            var success = await _service.UpdateProductInventory(articleNumber, location, newQuantity);

            if (success)
            {
                return Ok(new { Message = "Inventory updated successfully." });
            }
            else
            {
                return NotFound(new { Message = "Product or location not found." });
            }
        }
        #endregion

        #region HTTP Post and Delete Methods
        [HttpPost("add-product")]
        public async Task<ActionResult> AddProduct([FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new { Message = "Validation errors", Errors = errors });
            }

            var success = await _service.AddProduct(productDto);

            if (success)
            {
                return Ok(new { Message = "Product added successfully." });
            }
            else
            {
                return BadRequest(new { Message = "Failed to add product." });
            }
        }

        [HttpDelete("delete-by-article/{articleNumber}")]
        public async Task<ActionResult> DeleteProductByArticleNumber(string articleNumber)
        {
            var success = await _service.DeleteProductByArticleNumber(articleNumber);

            if (success)
            {
                return Ok(new { Message = "Product deleted successfully." });
            }
            else
            {
                return NotFound(new { Message = "Product not found." });
            }
        }
        #endregion
    }
}
