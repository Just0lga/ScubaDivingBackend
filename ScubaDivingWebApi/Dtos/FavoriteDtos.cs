// FavoriteCreateDto.cs
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class FavoriteCreateDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }

    public class FavoriteReadDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
