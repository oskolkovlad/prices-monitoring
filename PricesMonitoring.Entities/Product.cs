using System.ComponentModel.DataAnnotations;

namespace PricesMonitoring.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Link { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? DiscountedPrice { get; set; }

        [Required]
        public Shop Shop { get; set; } = null!;
    }
}
