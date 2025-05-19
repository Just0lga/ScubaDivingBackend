using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ScubaDivingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public FavoritesController(IFavoriteRepository favoriteRepository, IProductRepository productRepository, IMapper mapper)
        {
            _favoriteRepository = favoriteRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<FavoriteReadDto>>> GetFavorites(string userId)
        {
            var favorites = await _favoriteRepository.GetAllFavoritesByUserId(userId);

            var favoritesDto = _mapper.Map<List<FavoriteReadDto>>(favorites);

            return Ok(favoritesDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddFavorite([FromBody] FavoriteCreateDto favoriteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _favoriteRepository.GetFavorite(favoriteDto.UserId, favoriteDto.ProductId);
            if (existing != null)
                return Conflict("Already in favorites.");

            var product = await _productRepository.GetProductByIdAsync(favoriteDto.ProductId);
            if (product == null)
                return NotFound("Product not found.");

            product.FavoriteCount++;
            await _productRepository.UpdateProductAsync(product);

            var favorite = _mapper.Map<Favorite>(favoriteDto);
            await _favoriteRepository.AddFavorite(favorite);

            return Ok();
        }

        [HttpDelete("{userId}/{productId}")]
        public async Task<ActionResult> RemoveFavorite(string userId, int productId)
        {
            var favorite = await _favoriteRepository.GetFavorite(userId, productId);
            if (favorite == null)
                return NotFound();

            var product = await _productRepository.GetProductByIdAsync(favorite.ProductId);
            if (product != null)
            {
                product.FavoriteCount--;
                await _productRepository.UpdateProductAsync(product);
            }

            await _favoriteRepository.RemoveFavorite(favorite);

            return NoContent();
        }
    }
}
