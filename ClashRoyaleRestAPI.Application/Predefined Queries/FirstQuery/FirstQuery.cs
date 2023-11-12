using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FirstQuery;

public record FirstQuery() : IQuery<IEnumerable<FirstQueryResponse>>;
