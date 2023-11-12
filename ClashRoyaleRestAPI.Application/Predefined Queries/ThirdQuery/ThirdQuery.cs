using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.ThirdQuery;

public record ThirdQuery() : IQuery<IEnumerable<ThirdQueryResponse>>;

