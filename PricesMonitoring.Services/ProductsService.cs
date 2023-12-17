﻿namespace PricesMonitoring.Services;

using Dto;
using Entities;
using Repositories;

public class ProductsService : IProductsService
{
    private readonly IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<List<ProductReadViewDto>> GetProducts()
    {
        var products = await _productsRepository.GetAllItemsAsync();
        // TODO: mapping from 'Product' to 'ProductReadViewDto'.
        
        return new List<ProductReadViewDto>();
    }

    public async Task<ProductReadViewDto> AddProduct(ProductCreateViewDto productCreateDto)
    {
        if (productCreateDto is null)
        {
            throw new ArgumentNullException(nameof(productCreateDto));
        }
        
        var products = await _productsRepository.GetAllItemsAsync();
        if (products.Any(product => product.Link == productCreateDto.Link))
        {
            throw new InvalidDataException("Данный товар уже был добавлен.");
        }
        
        // TODO: get product info by shop parser.
        // TODO: mapping from 'ProductCreateDto' to 'Product'.
        Product product = new Product();
        await _productsRepository.CreateItemAsync(product);
        
        // TODO: mapping from 'Product' to 'ProductReadViewDto'.

        return new ProductReadViewDto();
    }

    public async Task DeleteProduct(int? id)
    {
        if (id is null)
        {
            throw new ArgumentNullException(nameof(id));
        }
        
        await _productsRepository.RemoveItemByIdAsync(id.Value);
    }
}