using System.ComponentModel.DataAnnotations;

public class CreateBannerDto
{
    [Required]
    public string ImageUrl { get; set; }

    [Required]
    public string RedirectUrl { get; set; }

    public string Title { get; set; }
}
