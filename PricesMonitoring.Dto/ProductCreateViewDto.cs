namespace PricesMonitoring.Dto;

public class ProductCreateViewDto
{
    public string? Link { get; set; }

    public ShopViewDto Shop { get; set; } = null!;
}
