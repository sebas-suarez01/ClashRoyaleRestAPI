using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.SecondQuery
{
    public record SecondQuery() : IQuery<IEnumerable<SecondQueryResponse>>;
}
