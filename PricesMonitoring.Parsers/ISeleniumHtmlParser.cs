namespace PricesMonitoring.Parsers;

public interface ISeleniumHtmlParser<out TDto>
{
    TDto? GetItem(string? url);
}
