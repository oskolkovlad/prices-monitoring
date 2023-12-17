namespace PricesMonitoring.ShopParsers;

using Elements;
using HtmlAgilityPack;
using OpenQA.Selenium;
using WebDriver;

public class OzonSeleniumHtmlParser : SeleniumHtmlParserBase<ProductDto>
{
    private static readonly string[] WordsToRemove = { "\u2009", "₽", "c Ozon Картой" };
    
    protected override ProductDto? GetItem(WebDriverProvider driverProvider)
    {
        var result = default(ProductDto?);
        
        try
        {
            result = driverProvider.FindElement(OzonPageElements.OzonCardPriceElement) is null ?
                GetProduct(driverProvider) :
                GetProductWithOzonCard(driverProvider);
        }
        catch (Exception ex)
        {
            // TODO: log error.
        }
        
        return result;
    }
    
    private static ProductDto? GetProduct(WebDriverProvider driverProvider)
    {
        var element = driverProvider.FindElement(OzonPageElements.PriceElement);
        var price = element?.Text.TrimText(WordsToRemove);

        if (string.IsNullOrWhiteSpace(price))
        {
            throw new ApplicationException("Цена товара не найдена.");
        }
        
        return new ProductDto
        {
            Name = GetProductName(driverProvider),
            Price = price.ParseText()
        };
    }

    private static ProductDto? GetProductWithOzonCard(WebDriverProvider driverProvider)
    {
        var element = driverProvider.FindElement(OzonPageElements.OzonCardPriceElement);
        var ozonCardPrice = element?.Text.TrimText(WordsToRemove);

        if (string.IsNullOrWhiteSpace(ozonCardPrice))
        {
            throw new ApplicationException("Цена товара с Ozon картой не найдена.");
        }
        
        element = driverProvider.FindElement(OzonPageElements.WithoutOzonCardPriceElement);
        var withoutOzonCardPrice = element?.Text.TrimText(WordsToRemove);
        
        if (string.IsNullOrWhiteSpace(withoutOzonCardPrice))
        {
            throw new ApplicationException("Цена товара без Ozon карты не найдена.");
        }

        return new ProductDto
        {
            Name = GetProductName(driverProvider),
            Price = withoutOzonCardPrice.ParseText(),
            DiscountedPrice = ozonCardPrice.ParseText()
        };
    }

    private static string GetProductName(WebDriverProvider driverProvider)
    {
        var element = driverProvider.FindElement(OzonPageElements.NameElement);
        var name = element?.Text.TrimText();
        
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ApplicationException("Наименование товара не найдено.");
        }
        
        return name;
    }
}
