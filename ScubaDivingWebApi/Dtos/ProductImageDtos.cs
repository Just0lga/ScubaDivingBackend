// ProductImageCreateDto.cs
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class ProductImageCreateDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }

    public class ProductImageReadDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
    }
}
