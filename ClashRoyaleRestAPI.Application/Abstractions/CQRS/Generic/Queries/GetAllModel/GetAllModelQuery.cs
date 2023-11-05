using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel
{
    public record GetAllModelQuery<TModel, UId>() : IQuery<IEnumerable<TModel>>
        where TModel : IEntity<UId>;
}
