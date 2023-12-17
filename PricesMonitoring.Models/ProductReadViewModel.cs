namespace PricesMonitoring.Models;

public class ProductReadViewDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Link { get; set; }

    public decimal Price { get; set; }

    public decimal? DiscountedPrice { get; set; }

    public ShopViewModel Shop { get; set; } = null!;
}
