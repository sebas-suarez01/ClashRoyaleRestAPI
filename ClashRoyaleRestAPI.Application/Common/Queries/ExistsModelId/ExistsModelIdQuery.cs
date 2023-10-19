using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Application.Common.Queries.ExistsModelId
{
    public record ExistsModelIdQuery<TModel, UId>(UId Id) : IQuery<bool>
        where TModel : IEntity<UId>;
}
