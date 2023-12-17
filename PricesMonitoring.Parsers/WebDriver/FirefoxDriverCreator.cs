namespace PricesMonitoring.Parsers.WebDriver;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

public class FirefoxDriverCreator : BaseWebDriverCreator, IWebDriverCreator
{
    #region IWebDriverCreator Members

    public IWebDriver Create()
    {
        var options = CreateDriverOptions<FirefoxOptions>();
        options.AddArgument(IncognitoModeArgument);

        return new FirefoxDriver(options);
    }

    #endregion IWebDriverCreator Members
}