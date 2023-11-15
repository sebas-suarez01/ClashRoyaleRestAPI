using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel;

public record GetAllModelQuery<TModel, UId>(int Page=1, int PageSize=10) : IQuery<PageList<TModel>>
    where TModel : IEntity<UId>;
