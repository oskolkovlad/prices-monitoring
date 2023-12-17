namespace PricesMonitoring.Models;

public class ProductCreateViewModel
{
    public string? Url { get; set; }

    public ShopViewModel Shop { get; set; } = null!;
}
