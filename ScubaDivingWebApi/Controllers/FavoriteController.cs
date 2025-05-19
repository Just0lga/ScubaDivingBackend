using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ScubaDivingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IProductRepository _productRepository;

        public FavoritesController(IFavoriteRepository favoriteRepository, IProductRepository productRepository)
        {
            _favoriteRepository = favoriteRepository;
            _productRepository = productRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IReadOnlyList<Favorite>>> GetFavorites(string userId)
        {
            var favorites = await _favoriteRepository.GetAllFavoritesByUserId(userId);

            return Ok(favorites);
        }

        [HttpPost]
        public async Task<ActionResult> AddFavorite([FromBody] Favorite favorite)
        {
            var existing = await _favoriteRepository.GetFavorite(favorite.UserId, favorite.ProductId);
            if (existing != null) return Conflict("Already in favorites.");
            var product = await _productRepository.GetProductByIdAsync(favorite.ProductId);
            product.FavoriteCount++;
            await _productRepository.UpdateProductAsync(product);
            await _favoriteRepository.AddFavorite(favorite);
            return Ok();
        }

        [HttpDelete("{userId}/{productId}")]
        public async Task<ActionResult> RemoveFavorite(string userId, int productId)
        {
            var favorite = await _favoriteRepository.GetFavorite(userId, productId);
            if (favorite == null) return NotFound();
            var product = await _productRepository.GetProductByIdAsync(favorite.ProductId);
            product.FavoriteCount--;
            await _productRepository.UpdateProductAsync(product);
            await _favoriteRepository.AddFavorite(favorite);

            await _favoriteRepository.RemoveFavorite(favorite);
            return NoContent();
        }
    }
}