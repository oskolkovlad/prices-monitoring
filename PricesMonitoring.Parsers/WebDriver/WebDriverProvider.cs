namespace PricesMonitoring.ShopParsers.WebDriver;

using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium;

public class WebDriverProvider
{
    private const string ScrollIntoViewScript = "arguments[0].scrollIntoView(true);";
            
    private IWebDriver? _webDriver;

    public WebDriverProvider([NotNull] IWebDriverCreator webDriverCreator) => _webDriver = webDriverCreator.Create();

    #region Public Members
            
    public string? Url => _webDriver?.Url;

    public void Close()
    {
        _webDriver?.Dispose();
        _webDriver = null;
    }

    public IWebElement? FindElement(By by)
    {
        try
        {
            return _webDriver?.FindElement(by);
        }
        catch (NoSuchElementException)
        {
            return null;
        }
    }
            
    public void GoToUrl(string url) => _webDriver?.Navigate()?.GoToUrl(url);
            
    public void MoveToElement(IWebElement? element)
    {
        if (_webDriver != null && element != null)
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript(ScrollIntoViewScript, element);
        }
    }

    #endregion Public Members
}
