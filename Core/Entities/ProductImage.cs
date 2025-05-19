using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

public class ProductImage : BaseEntity
{
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    public string ImageUrl { get; set; }
}
