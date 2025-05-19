using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BannerController : ControllerBase
{
    private readonly IBannerRepository _bannerRepository;

    public BannerController(IBannerRepository bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Banner>>> GetBanners()
    {
        var banners = await _bannerRepository.GetAllBannersAsync();
        return Ok(banners);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Banner>> GetBanner(int id)
    {
        var banner = await _bannerRepository.GetBannerByIdAsync(id);
        if (banner == null) return NotFound();
        return Ok(banner);
    }

    [HttpPost]
    public async Task<ActionResult> CreateBanner([FromBody] CreateBannerDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var banner = new Banner
        {
            ImageUrl = dto.ImageUrl,
            RedirectUrl = dto.RedirectUrl,
            Title = dto.Title
        };

        await _bannerRepository.AddBannerAsync(banner);
        return CreatedAtAction(nameof(GetBanner), new { id = banner.Id }, banner);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBanner(int id, [FromBody] Banner banner)
    {
        if (id != banner.Id) return BadRequest("Id mismatch");

        var existingBanner = await _bannerRepository.GetBannerByIdAsync(id);
        if (existingBanner == null) return NotFound();

        existingBanner.Title = banner.Title;
        existingBanner.ImageUrl = banner.ImageUrl;
        existingBanner.RedirectUrl = banner.RedirectUrl;

        await _bannerRepository.UpdateBannerAsync(existingBanner);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBanner(int id)
    {
        var banner = await _bannerRepository.GetBannerByIdAsync(id);
        if (banner == null) return NotFound();

        await _bannerRepository.DeleteBannerAsync(banner);

        return NoContent();
    }
}
