namespace PricesMonitoring.Entities;

using System.ComponentModel.DataAnnotations;

public class Product : IdentityEntity
{
    [Required]
    public string Name { get; set; } = null!;

    public string? Link { get; set; }

    [Required]
    public decimal Price { get; set; }

    public decimal? DiscountedPrice { get; set; }

    [Required]
    public Shop Shop { get; set; } = null!;
}