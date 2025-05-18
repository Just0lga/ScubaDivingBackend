
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }

        public virtual ICollection<Address> Adresses { get; set; } = new List<Address>();

        public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
