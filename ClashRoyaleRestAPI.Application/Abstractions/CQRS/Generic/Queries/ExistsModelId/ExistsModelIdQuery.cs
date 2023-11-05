using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.ExistsModelId
{
    public record ExistsModelIdQuery<UId>(UId Id) : IQuery<bool>;
}
