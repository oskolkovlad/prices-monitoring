namespace PricesMonitoring.Repositories;

using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

public class ProductsRepository : IProductsRepository
{
    private readonly PricesMonitoringDbContext _context;

    public ProductsRepository(PricesMonitoringDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAllItems() => _context.Products.ToList();
    
    public async Task<List<Product>> GetAllItemsAsync() => await _context.Products.ToListAsync();
    
    public Product? GetItemById(int id) => _context.Products.FirstOrDefault(product => product.Id == id);

    public async Task<Product?> GetItemByIdAsync(int id) => await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
    
    public void CreateItem(Product? entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Products.Add(entity);
    }

    public async Task CreateItemAsync(Product? entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await _context.Products.AddAsync(entity);
    }
    
    public void DeleteItemById(int id)
    {
        var product = GetItemById(id);
        if (product is not null)
        {
            _context.Products.Remove(product);
        }
    }

    public async Task RemoveItemByIdAsync(int id)
    {
        var product = await GetItemByIdAsync(id);
        if (product is not null)
        {
            _context.Products.Remove(product);
        }
    }

    public void UpdateItem(Product? entity)
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
