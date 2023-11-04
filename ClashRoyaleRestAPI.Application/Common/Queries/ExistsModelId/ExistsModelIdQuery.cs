using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Common.Queries.ExistsModelId
{
    public record ExistsModelIdQuery<UId>(UId Id) : IQuery<bool>;
}
