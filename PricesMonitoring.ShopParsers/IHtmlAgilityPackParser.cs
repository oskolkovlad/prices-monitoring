namespace PricesMonitoring.ShopParsers;

public interface IHtmlAgilityPackParser<TDto>
{
    Task<TDto?> GetItemAsync(string? url);
}
