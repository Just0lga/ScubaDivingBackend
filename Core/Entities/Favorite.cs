using Core.Entities;
using System.ComponentModel.DataAnnotations;

public class Favorite : BaseEntity
{
    [Required]
    public string UserId { get; set; }
    public User User { get; set; } // ✅ Navigation property

    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; } // ✅ Navigation property

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
