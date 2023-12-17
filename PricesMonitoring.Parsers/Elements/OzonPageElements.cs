namespace PricesMonitoring.Parsers.Elements;

using OpenQA.Selenium;

internal static class OzonPageElements
{
    public static readonly By NameElement = By.XPath(".//div[@data-widget='webProductHeading']/h1");
    
    public static readonly By PriceContainerElement = By.XPath(".//div[@data-widget='webPrice']");
    
    public static readonly By OzonCardPriceElement = By.XPath(".//div[@data-widget='webPrice']/div[1]/div[1]/button");
    
    public static readonly By OzonCardPriceButtonElement = By.XPath(".//div[@data-widget='webPrice']/div/div/button/span/div/div[1]/div/div/span"); // /html/body/div[1]/div/div[1]/div[4]/div[3]/div[2]/div[2]/div/div[1]/div[1]/div/div/div[1]/div[1]/button/span/div/div[1]/div/div/span
    
    public static readonly By WithoutOzonCardPriceElement = By.XPath(".//div[@data-widget='webPrice']/div[1]/div[2]/div/div[1]/span"); // /html/body/div[1]/div/div[1]/div[4]/div[3]/div[2]/div[2]/div/div[1]/div[1]/div/div/div[1]/div[2]/div/div[1]/span
    
    public static readonly By PriceElement = By.XPath(".//div[@data-widget='webPrice']/div[1]/div/div/div[1]/span");
}
