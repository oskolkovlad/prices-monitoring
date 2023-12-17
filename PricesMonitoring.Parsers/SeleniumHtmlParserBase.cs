namespace PricesMonitoring.Parsers;

using WebDriver;

public abstract class SeleniumHtmlParserBase<TDto> : ISeleniumHtmlParser<TDto>
{
    #region IBondParser Members

    public TDto? GetItem(string? url) => Parse(url);

    #endregion IBondParser Members
    
    #region Protected Members

    protected abstract TDto? GetItem(WebDriverProvider driverProvider);

    #endregion Protected Members

    #region Private Members
    
    private TDto? Parse(string? url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return default;
        }

        var driverProvider = default(WebDriverProvider);

        try
        {
            driverProvider = new WebDriverProvider(new ChromeDriverCreator()); // TODO: create driver by config setting.
            driverProvider.GoToUrl(url);

            return GetItem(driverProvider);
        }
        catch (Exception exception)
        {
            // TODO: log error.
        }
        finally
        {
            driverProvider?.Close();
        }

        return default;
    }

    #endregion Private Members
}
