namespace PricesMonitoring.ShopParsers;

using HtmlAgilityPack;

public abstract class HtmlAgilityPackParserBase<TDto> : IHtmlAgilityPackParser<TDto>
{
    #region IBondParser Members

    public Task<TDto?> GetItemAsync(string? url) => ParseAsync(url);

    #endregion IBondParser Members
    
    #region Protected Members

    protected abstract TDto? GetItem(HtmlDocument document);

    #endregion Protected Members

    #region Private Members
    
    private async Task<TDto?> ParseAsync(string? url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return default;
        }
        
        var htmlContent = await GetHtmlContentAsync(url).ConfigureAwait(false);
        if (string.IsNullOrEmpty(htmlContent))
        {
            return default;
        }

        try
        {
            var document = new HtmlDocument();
            document.LoadHtml(htmlContent);
            
            return GetItem(document);
        }
        catch (Exception exception)
        {
            // TODO: log error.
        }

        return default;
    }

    private static async Task<string?> GetHtmlContentAsync(string url)
    {
        try
        {
            using var handler = new HttpClientHandler();
            using var httpClient = new HttpClient(handler);
            using var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            {
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var htmlContent = await response.Content.ReadAsStringAsync();
                return htmlContent;
            }
        }
        catch (Exception exception)
        {
            // TODO: log error.
        }

        return null;
    }

    #endregion Private Members
}
