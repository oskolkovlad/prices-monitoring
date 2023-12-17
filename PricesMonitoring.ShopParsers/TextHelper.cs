namespace PricesMonitoring.ShopParsers;

using System.Globalization;

internal static class TextHelper
{
    public static decimal ParseText(this string value) => decimal.Parse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);

    public static string? TrimText(this string? text, params string[] wordsToRemove)
    {
        if (text is null)
        {
            return null;
        }
        
        var result = wordsToRemove.Aggregate(text, (current, removeChar) => current.Replace(removeChar, string.Empty));
        return result?.Trim('\n', '\t', '\r', ' ');
    }
}
