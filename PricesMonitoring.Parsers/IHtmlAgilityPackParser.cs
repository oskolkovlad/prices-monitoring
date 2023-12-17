namespace PricesMonitoring.Parsers;

public interface IHtmlAgilityPackParser<TDto>
{
    Task<TDto?> GetItemAsync(string? url);
}
