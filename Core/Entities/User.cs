using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }

        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<SearchHistory> SearchHistory { get; set; } = new List<SearchHistory>();
    }
}
