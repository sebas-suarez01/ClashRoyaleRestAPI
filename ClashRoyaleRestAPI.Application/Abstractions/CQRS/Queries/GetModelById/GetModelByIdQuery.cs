using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetModelById
{
    public record GetModelByIdQuery<TModel, UId>(UId Id) : IQuery<TModel>
        where TModel : IEntity<UId>;
}
