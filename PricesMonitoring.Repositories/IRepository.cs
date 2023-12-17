namespace PricesMonitoring.Repositories;

using Entities;

public interface IRepository<TEntity> where TEntity : IdentityEntity
{
    List<TEntity> GetAllItems();
    
    Task<List<TEntity>> GetAllItemsAsync();

    TEntity? GetItemById(int id);

    Task<TEntity?> GetItemByIdAsync(int id);

    void CreateItem(TEntity? entity);

    Task CreateItemAsync(TEntity? entity);

    void DeleteItemById(int id);

    Task DeleteItemByIdAsync(int id);

    void UpdateItem(TEntity? entity);

    bool SaveChanges();

    Task<bool> SaveChangesAsync();
}
