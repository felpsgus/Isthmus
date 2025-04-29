using Isthmus.Application.Products.Models;
using Isthmus.Domain.Common.Pagination;
using Isthmus.Domain.Entities;

namespace Isthmus.Application.Products;

public interface IProductService
{
    Task<Product> CreateProduct(ProductModel model, CancellationToken cancellationToken = default);

    Task<Product?> UpdateProduct(ProductModel model, CancellationToken cancellationToken = default);

    Task<Product?> DeleteProduct(int id, CancellationToken cancellationToken = default);

    Task<IPagedList<Product>> GetProductsAsync(
        string? searchTerm,
        bool? isActive,
        int page = 1,
        int pageSize = 100,
        CancellationToken cancellationToken = default);
}