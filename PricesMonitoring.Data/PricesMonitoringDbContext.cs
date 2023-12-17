namespace PricesMonitoring.Data;

using Microsoft.EntityFrameworkCore;
using PricesMonitoring.Entities;

public class PricesMonitoringDbContext : DbContext
{
    public PricesMonitoringDbContext(DbContextOptions options) : base(options)
    {
        // TODO: создавать БД, если отстуствует файл.
        //Database.EnsureCreated();
    }

    public DbSet<Shop> Shops { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Shop>()
            .HasMany(shop => shop.Products)
            .WithOne(product => product.Shop)
            .HasForeignKey(product => product.Shop);

        modelBuilder
            .Entity<Product>()
            .HasOne(product => product.Shop)
            .WithMany(shop => shop.Products)
            .HasForeignKey(product => product.Shop);
    }
}
