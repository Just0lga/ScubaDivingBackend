using Core.Entities;

namespace Core.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<IReadOnlyList<Favorite>> GetAllFavoritesByUserId(string userId);
        Task<Favorite> GetFavorite(string userId, int productId);
        Task AddFavorite(Favorite favorite);
        Task RemoveFavorite(Favorite favorite);
    }
}