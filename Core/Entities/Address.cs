using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Address : BaseEntity
    {
        [Required]
        public string UserId { get; set; } 
        public User User { get; set; }
        public string Title { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
    }
}
