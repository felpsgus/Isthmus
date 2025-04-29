using Isthmus.Domain.Common.Pagination;

namespace Isthmus.Application.Common.Pagination;

public class PagedList<T> : IPagedList<T>
{
    private PagedList(ICollection<T> list, int page, int pageSize, int totalCount)
    {
        Items = list.ToList();
        CurrentPage = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public IReadOnlyList<T> Items { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool IsPreviousPageExists => CurrentPage > 1;
    public bool IsNextPageExists => CurrentPage < TotalPages;

    public static PagedList<T> Create(ICollection<T> list, int page, int pageSize, int totalCount)
    {
        return new PagedList<T>(list, page, pageSize, totalCount);
    }
}