using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FourthQuery;

public record FourthQuery() : IQuery<IEnumerable<FourthQueryResponse>>;
