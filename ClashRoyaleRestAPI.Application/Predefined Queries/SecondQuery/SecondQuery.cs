using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.SecondQuery
{
    public record SecondQuery() : IQuery<IEnumerable<SecondQueryResponse>>;
}
