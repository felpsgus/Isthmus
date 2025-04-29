namespace Isthmus.Domain.Common.Pagination;

public interface IPagedList<T>
{
    IReadOnlyList<T> Items { get; set; }
    int CurrentPage { get; set; }
    int PageSize { get; set; }
    int TotalCount { get; set; }
    int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    bool IsPreviousPageExists => CurrentPage > 1;
    bool IsNextPageExists => CurrentPage < TotalPages;
}