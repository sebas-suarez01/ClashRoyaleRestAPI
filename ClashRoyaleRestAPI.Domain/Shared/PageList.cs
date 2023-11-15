namespace ClashRoyaleRestAPI.Domain.Shared;

public class PageList<T>
{
    public PageList(List<T> items, int page, int pageSize, int totalCount)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }
    public List<T> Items { get; }
    public int Page { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public bool HasNextPage => Page * PageSize < TotalCount;
    public bool HasPreviousPage => Page > 1;
    public static PageList<T> Create(IQueryable<T> query, int page, int pageSize)
    {
        int count = query.Count();
        var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return new(items, page, pageSize, count);
    }
}
