namespace PricesMonitoring.Entities;

using System.ComponentModel.DataAnnotations;

public class Shop : IdentityEntity
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Code { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}