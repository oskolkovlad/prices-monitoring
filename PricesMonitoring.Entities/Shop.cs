using System.ComponentModel.DataAnnotations;

namespace PricesMonitoring.Entities
{
    public class Shop
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Code { get; set; } = null!;
    }
}
