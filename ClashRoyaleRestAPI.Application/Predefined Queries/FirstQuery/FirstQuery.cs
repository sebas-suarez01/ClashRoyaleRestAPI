using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FirstQuery;

public record FirstQuery() : IQuery<IEnumerable<FirstQueryResponse>>;
