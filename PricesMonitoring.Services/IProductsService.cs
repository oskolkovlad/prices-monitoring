namespace PricesMonitoring.Services;

using Dto;

public interface IProductsService
{
    Task<List<ProductReadViewDto>> GetProducts();

    Task<ProductReadViewDto> AddProduct(ProductCreateViewDto productCreateDto);

    Task DeleteProduct(int? id);
}
