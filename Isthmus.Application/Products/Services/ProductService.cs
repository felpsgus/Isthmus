using FluentValidation;
using Isthmus.Application.Products.Models;
using Isthmus.Application.Products.Validators;
using Isthmus.Domain.Common.Pagination;
using Isthmus.Domain.Entities;
using Isthmus.Domain.Repositories;

namespace Isthmus.Application.Products.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ProductModelValidator _validator;

    public ProductService(IProductRepository productRepository, ProductModelValidator productModelValidator)
    {
        _productRepository = productRepository;
        _validator = productModelValidator;
    }

    public async Task<Product> CreateProduct(ProductModel model, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(model, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var product = Product.Create(model.Code, model.Name, model.Description, model.Price);

        return await _productRepository.CreateAsync(product, cancellationToken);
    }

    public async Task<Product?> UpdateProduct(ProductModel model, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(model, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var product = await _productRepository.GetByCodeAsync(model.Code, cancellationToken);
        if (product == null)
        {
            return null;
        }

        product.Update(model.Code, model.Name, model.Description, model.Price);

        return await _productRepository.UpdateAsync(product, cancellationToken);
    }

    public async Task<Product?> DeleteProduct(int id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id, cancellationToken);
        if (product == null)
        {
            return null;
        }

        product.Inactivate();

        return await _productRepository.UpdateAsync(product, cancellationToken);
    }

    public Task<IPagedList<Product>> GetProductsAsync(
        string? searchTerm,
        bool? isActive,
        int page = 1,
        int pageSize = 100,
        CancellationToken cancellationToken = default)
    {
        return _productRepository.GetFilteredAsync(
            searchTerm,
            isActive,
            page,
            pageSize,
            cancellationToken
        );
    }
}