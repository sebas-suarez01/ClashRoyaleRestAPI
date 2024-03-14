using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.SeventhQuery;

public record SeventhQuery(int Year) : IQuery<IEnumerable<SeventhQueryResponse>>;
