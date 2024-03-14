using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.ThirdQuery;

public record ThirdQuery() : IQuery<IEnumerable<ThirdQueryResponse>>;

