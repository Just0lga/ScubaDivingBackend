using Core.Entities;

namespace Core.Interfaces
{
    public interface ISearchHistoryRepository
    {
        Task<IEnumerable<SearchHistory>> GetLastSearchesAsync(string userId, int count = 10);
        Task AddAsync(SearchHistory searchHistory);
        Task DeleteAsync(int id, string userId);
    }
}
