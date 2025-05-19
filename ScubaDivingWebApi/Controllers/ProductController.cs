using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ScubaDivingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Core.Interfaces.IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(Core.Interfaces.IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // Tüm ürünleri getir  
        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        // ID'ye göre ürün getir  
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            product.ReviewCount++;
            await _productRepository.UpdateProductAsync(product);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // Kategori ID'ye göre ürünleri getir  
        [HttpGet("category/{id}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategoryId(int id)
        {
            var products = await _productRepository.GetProductsByCategoryId(id);
            if (products == null || products.Count == 0)
                return NotFound("No products found in this category");
            return Ok(products);
        }

        //En çok görüntülenenler
        // En çok görüntülenen ürünleri getir (varsayılan: 3 ürün)
        [HttpGet("top-viewed")]
        public async Task<ActionResult<List<Product>>> GetTopViewedProducts([FromQuery] int count = 3)
        {
            var products = await _productRepository.GetTopViewedProductsAsync(count);
            if (products == null || products.Count == 0)
                return NotFound("No top viewed products found");

            return Ok(products);
        }

        // Yeni ürün oluştur  
        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductDtos createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productRepository.CreateProductAsync(product);
            return Ok();
        }

        // En çok favoriye eklenen ürünleri getir
        [HttpGet("most-favorited")]
        public async Task<ActionResult<List<Product>>> GetMostFavoritedProducts([FromQuery] int count = 3)
        {
            var products = await _productRepository.GetMostFavoritedProductsAsync(count);
            if (products == null || products.Count == 0)
                return NotFound("No favorited products found");

            return Ok(products);
        }


        // Ürünü güncelle  
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return NotFound("Product not found");

            _mapper.Map(updateProductDto, product);
            product.UpdatedAt = DateTime.UtcNow;

            await _productRepository.UpdateProductAsync(product);
            return Ok();
        }

        // Ürünü sil  
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
