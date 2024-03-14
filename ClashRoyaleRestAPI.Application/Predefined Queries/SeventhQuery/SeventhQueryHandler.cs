using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.SeventhQuery;

internal class SeventhQueryHandler : IQueryHandler<SeventhQuery, IEnumerable<SeventhQueryResponse>>
{
    private readonly IPredefinedQueries _queries;

    public SeventhQueryHandler(IPredefinedQueries queries)
    {
        _queries = queries;
    }

    public async Task<Result<IEnumerable<SeventhQueryResponse>>> Handle(SeventhQuery request, CancellationToken cancellationToken)
    {
        var result = await _queries.SeventhQuery(request.Year);

        return Result.Create(result);
    }
}
