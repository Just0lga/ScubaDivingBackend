// ProductImageController.cs
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ScubaDivingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public ProductImageController(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        // POST: api/ProductImage
        [HttpPost]
        public async Task<ActionResult<ProductImageReadDto>> CreateProductImage([FromBody] ProductImageCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Image data cannot be null");

            var productImage = _mapper.Map<ProductImage>(dto);

            await _productImageRepository.AddProductImageAsync(productImage);

            var result = _mapper.Map<ProductImageReadDto>(productImage);

            return CreatedAtAction(nameof(GetProductImage), new { id = productImage.Id }, result);
        }

        // GET: api/ProductImage/Product/5
        [HttpGet("Product/{productId}")]
        public async Task<ActionResult<List<ProductImageReadDto>>> GetImagesByProductId(int productId)
        {
            var images = await _productImageRepository.GetProductImagesByProductIdAsync(productId);
            if (images == null || images.Count == 0)
                return NotFound();

            var imagesDto = _mapper.Map<List<ProductImageReadDto>>(images);
            return Ok(imagesDto);
        }


        // GET: api/ProductImage/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductImageReadDto>> GetProductImage(int id)
        {
            var image = await _productImageRepository.GetProductImageByIdAsync(id);
            if (image == null) return NotFound();

            return Ok(_mapper.Map<ProductImageReadDto>(image));
        }

        // DELETE: api/ProductImage/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductImage(int id)
        {
            var image = await _productImageRepository.GetProductImageByIdAsync(id);
            if (image == null) return NotFound();

            await _productImageRepository.DeleteProductImageAsync(image);
            return NoContent();
        }
    }
}
