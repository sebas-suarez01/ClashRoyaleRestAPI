using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.SixthQuery;

public record SixthQuery() : IQuery<IEnumerable<SixthQueryResponse>>;
