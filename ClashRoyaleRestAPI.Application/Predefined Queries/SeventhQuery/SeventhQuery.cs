using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.SeventhQuery;

public record SeventhQuery(int Year) : IQuery<IEnumerable<SeventhQueryResponse>>;
