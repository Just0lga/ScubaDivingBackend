using System.ComponentModel.DataAnnotations;
using Core.Entities;

public class Banner: BaseEntity
{
    [Required]
    public string ImageUrl { get; set; }

    [Required]
    public string RedirectUrl { get; set; }

    public string Title { get; set; }
}
