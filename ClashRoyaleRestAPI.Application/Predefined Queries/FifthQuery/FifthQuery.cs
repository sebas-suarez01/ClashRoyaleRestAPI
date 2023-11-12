using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FifthQuery;

public record FifthQuery(int trophies) : IQuery<IEnumerable<FifthQueryResponse>>;
