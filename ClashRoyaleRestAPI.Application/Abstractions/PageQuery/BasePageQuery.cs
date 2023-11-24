namespace ClashRoyaleRestAPI.Application.Abstractions.PageQuery;

public class BasePageQuery
{
    public BasePageQuery(string? sortColumn, string? sortOrder, int page = 1, int pageSize = 10)
    {
        SortColumn = sortColumn;
        SortOrder = sortOrder;
        PageSize = pageSize;
        Page = page;
    }

    public string? SortColumn { get; set; }
    public string? SortOrder { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
}
