using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly AppDbContext _context;

        public SearchHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SearchHistory>> GetLastSearchesAsync(string userId, int count = 10)
        {
            return await _context.SearchHistories
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task AddAsync(SearchHistory searchHistory)
        {
            await _context.SearchHistories.AddAsync(searchHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var search = await _context.SearchHistories
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (search != null)
            {
                _context.SearchHistories.Remove(search);
                await _context.SaveChangesAsync();
            }
        }
    }
}
