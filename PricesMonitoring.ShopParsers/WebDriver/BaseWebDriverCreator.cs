namespace PricesMonitoring.ShopParsers.WebDriver;

using OpenQA.Selenium;

public abstract class BaseWebDriverCreator
{
    #region Protected Members

    protected const string IncognitoModeArgument = "--incognito";

    protected TOptions CreateDriverOptions<TOptions>() where TOptions : DriverOptions, new() =>
        new() { AcceptInsecureCertificates = true };

    #endregion Protected Members
}