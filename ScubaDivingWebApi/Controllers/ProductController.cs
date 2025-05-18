using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScubaDivingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            await _productRepository.CreateProductAsync(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product updatedProduct)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return NotFound("Product not found");

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Brand = updatedProduct.Brand;
            product.Price = updatedProduct.Price;
            product.DiscountPrice = updatedProduct.DiscountPrice;
            product.Stock = updatedProduct.Stock;
            product.Rating = updatedProduct.Rating;
            product.ReviewCount = updatedProduct.ReviewCount;
            product.Features = updatedProduct.Features;
            product.IsActive = updatedProduct.IsActive;
            product.UpdatedAt = DateTime.UtcNow;

            await _productRepository.UpdateProductAsync(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return NotFound("Product not found");

            await _productRepository.DeleteProductAsync(product);
            return Ok();
        }
    }
}