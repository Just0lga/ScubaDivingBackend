using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BannerRepository : IBannerRepository
{
    private readonly AppDbContext _context;

    public BannerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Banner>> GetAllBannersAsync()
    {
        return await _context.Banners.ToListAsync();
    }

    public async Task<Banner> GetBannerByIdAsync(int id)
    {
        return await _context.Banners.FindAsync(id);
    }

    public async Task AddBannerAsync(Banner banner)
    {
        await _context.Banners.AddAsync(banner);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBannerAsync(Banner banner)
    {
        _context.Banners.Update(banner);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBannerAsync(Banner banner)
    {
        _context.Banners.Remove(banner);
        await _context.SaveChangesAsync();
    }
}
