using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBannerRepository
{
    Task<IEnumerable<Banner>> GetAllBannersAsync();
    Task<Banner> GetBannerByIdAsync(int id);
    Task AddBannerAsync(Banner banner);
    Task UpdateBannerAsync(Banner banner);
    Task DeleteBannerAsync(Banner banner);
}
