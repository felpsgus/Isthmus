using Isthmus.Domain.Common.Pagination;
using Isthmus.Domain.Entities;

namespace Isthmus.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);

    Task<IPagedList<Product>> GetFilteredAsync(
        string? searchTerm,
        bool? isActive,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<Product?> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
}