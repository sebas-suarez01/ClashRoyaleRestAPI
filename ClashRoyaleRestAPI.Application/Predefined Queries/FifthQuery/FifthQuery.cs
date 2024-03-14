using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FifthQuery;

public record FifthQuery(int trophies) : IQuery<IEnumerable<FifthQueryResponse>>;
