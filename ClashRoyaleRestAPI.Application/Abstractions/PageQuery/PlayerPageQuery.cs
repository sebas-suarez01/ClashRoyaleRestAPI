namespace ClashRoyaleRestAPI.Application.Abstractions.PageQuery;

public class PlayerPageQuery : BasePageQuery
{
    public PlayerPageQuery(string? name,
                           int? elo,
                           string? sortColumn,
                           string? sortOrder,
                           int page = 1,
                           int pageSize = 10)
        : base(sortColumn, sortOrder, page, pageSize)
    {
        Name = name;
        Elo = elo;
    }

    public string? Name { get; set; }
    public int? Elo { get; set; }
}
