using System.ComponentModel.DataAnnotations;

public class ProductDtos
{
    [Required]
    public string Name { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public string Description { get; set; }

    [Required]
    public string Brand { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? DiscountPrice { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    public Dictionary<string, string> Features { get; set; }

    public bool IsActive { get; set; } = true;
}

public class UpdateProductDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public string Description { get; set; }

    [Required]
    public string Brand { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? DiscountPrice { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    public Dictionary<string, string> Features { get; set; }

    public bool IsActive { get; set; } = true;
}
