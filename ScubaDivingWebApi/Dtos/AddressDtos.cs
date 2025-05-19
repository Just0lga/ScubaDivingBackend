using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class AddressCreateDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string FullAddress { get; set; }

        [Required]
        public string City { get; set; }

        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
    }

    public class AddressUpdateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string FullAddress { get; set; }

        [Required]
        public string City { get; set; }

        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
    }

    public class AddressReadDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
    }
}
