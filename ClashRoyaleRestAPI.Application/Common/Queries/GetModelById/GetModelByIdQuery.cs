using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Application.Common.Queries.GetModelById
{
    public record GetModelByIdQuery<TModel, UId>(UId Id) : IQuery<TModel>
        where TModel : IEntity<UId>;
}
