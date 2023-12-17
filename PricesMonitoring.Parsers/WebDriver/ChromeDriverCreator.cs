namespace PricesMonitoring.Parsers.WebDriver;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class ChromeDriverCreator : BaseWebDriverCreator, IWebDriverCreator
{
    #region IWebDriverCreator Members

    public IWebDriver Create()
    {
        var options = CreateDriverOptions<ChromeOptions>();
        options.AddArgument(IncognitoModeArgument);

        return new ChromeDriver(options);
    }

    #endregion IWebDriverCreator Members
}