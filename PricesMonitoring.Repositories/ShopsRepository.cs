namespace PricesMonitoring.Repositories;

using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

public class ShopRepository : IShopsRepository
{
    private readonly PricesMonitoringDbContext _context;

    public ShopRepository(PricesMonitoringDbContext context)
    {
        _context = context;
    }

    public List<Shop> GetAllItems() => _context.Shops.ToList();
    
    public async Task<List<Shop>> GetAllItemsAsync() => await _context.Shops.ToListAsync();
    
    public Shop? GetItemById(int id) => _context.Shops.FirstOrDefault(shop => shop.Id == id);

    public async Task<Shop?> GetItemByIdAsync(int id) => await _context.Shops.FirstOrDefaultAsync(shop => shop.Id == id);
    
    public void CreateItem(Shop? entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Shops.Add(entity);
    }

    public async Task CreateItemAsync(Shop? entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await _context.Shops.AddAsync(entity);
    }
    
    public void DeleteItemById(int id)
    {
        var shop = GetItemById(id);
        if (shop is not null)
        {
            _context.Shops.Remove(shop);
        }
    }

    public async Task RemoveItemByIdAsync(int id)
    {
        var shop = await GetItemByIdAsync(id);
        if (shop is not null)
        {
            _context.Shops.Remove(shop);
        }
    }

    public void UpdateItem(Shop? entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Update(entity);
    }
    
    public bool SaveChanges() => _context.SaveChanges() >= 0;

    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() >= 0;
}
