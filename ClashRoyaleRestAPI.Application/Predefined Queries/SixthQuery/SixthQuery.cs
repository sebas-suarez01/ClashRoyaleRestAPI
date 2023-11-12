using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.SixthQuery;

public record SixthQuery() : IQuery<IEnumerable<SixthQueryResponse>>;
