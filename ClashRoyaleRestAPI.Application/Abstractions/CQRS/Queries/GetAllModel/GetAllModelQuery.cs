using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetAllModel;

public record GetAllModelQuery<TModel, UId>(
    string? SortOrder,
    int Page = 1,
    int PageSize = 10) : ICachedQuery<PageList<TModel>>
    where TModel : IEntity<UId>
{
    public string CacheKey => $"{typeof(TModel)}-all";
    public TimeSpan? Expiration => null;
}
