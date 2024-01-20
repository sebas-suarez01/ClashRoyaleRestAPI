using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById
{
    public record GetModelByIdQuery<TModel, UId>(UId Id) : IQuery<TModel>
        where TModel : IEntity<UId>;
}
