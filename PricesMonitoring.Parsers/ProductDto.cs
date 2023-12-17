namespace PricesMonitoring.Parsers;

using System.ComponentModel.DataAnnotations;

public class ProductDto
{
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public decimal Price { get; set; }

    public decimal? DiscountedPrice { get; set; }
}
