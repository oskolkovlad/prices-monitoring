namespace PricesMonitoring.Models;

public class ProductCreateViewModel
{
    public string? Link { get; set; }

    public ShopViewModel Shop { get; set; } = null!;
}
