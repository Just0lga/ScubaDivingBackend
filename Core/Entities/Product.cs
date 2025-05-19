using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int Stock { get; set; }
        public decimal? Rating { get; set; }
        public int ReviewCount { get; set; }
        public Dictionary<string, string> Features { get; set; } = new();
        public bool IsActive { get; set; } = true;
        public int FavoriteCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>(); // ✅
        public List<ProductImage> ProductImages { get; set; } = new();

    }
}
