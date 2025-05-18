using Core.Entities;

public class ProductImage : BaseEntity
{
    public string Url { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
