namespace PricesMonitoring.ShopParsers;

public interface ISeleniumHtmlParser<out TDto>
{
    TDto? GetItem(string? url);
}
