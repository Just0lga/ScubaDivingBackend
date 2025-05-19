using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _context;

        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Favorite>> GetAllFavoritesByUserId(string userId)
        {
            return await _context.Favorites
                .Where(f => f.UserId == userId)
                .ToListAsync(); // Include kaldırıldı
        }

        public async Task<Favorite> GetFavorite(string userId, int productId)
        {
            return await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ProductId == productId);
        }

        public async Task AddFavorite(Favorite favorite)
        {
            favorite.CreatedAt = DateTime.UtcNow;
            favorite.UpdatedAt = DateTime.UtcNow;

            await _context.Favorites.AddAsync(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavorite(Favorite favorite)
        {
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
        }
    }
}
