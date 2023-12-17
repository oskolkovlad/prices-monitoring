namespace PricesMonitoring.Entities;

using System.ComponentModel.DataAnnotations;

public abstract class IdentityEntity
{
    [Key]
    [Required]
    public int Id { get; set; }
}
