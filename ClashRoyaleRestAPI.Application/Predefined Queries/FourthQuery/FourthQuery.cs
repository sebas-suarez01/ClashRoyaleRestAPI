using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FourthQuery;

public record FourthQuery() : IQuery<IEnumerable<FourthQueryResponse>>;
