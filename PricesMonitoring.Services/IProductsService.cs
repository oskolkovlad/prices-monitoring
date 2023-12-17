namespace PricesMonitoring.Services;

using Models;

public interface IProductsService
{
    Task<List<ProductReadViewDto>> GetProducts();

    Task<ProductReadViewDto> AddProduct(ProductCreateViewModel productCreateModel);

    Task DeleteProduct(int? id);
}
