using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductImageRepository
    {
        Task<List<ProductImage>> GetProductImagesByProductIdAsync(int productId);
        Task<ProductImage> GetProductImageByIdAsync(int id);
        Task AddProductImageAsync(ProductImage image);
        Task DeleteProductImageAsync(ProductImage image);
    }
}
