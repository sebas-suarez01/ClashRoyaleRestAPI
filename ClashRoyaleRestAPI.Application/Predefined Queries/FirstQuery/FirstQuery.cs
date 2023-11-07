using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Responses;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FirstQuery
{
    public record FirstQuery() : IQuery<IEnumerable<FirstQueryResponse>>;
}
