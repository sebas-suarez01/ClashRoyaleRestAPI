using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.SixthQuery;

internal class SixthQueryHandler : IQueryHandler<SixthQuery, IEnumerable<SixthQueryResponse>>
{
    private readonly IPredefinedQueries _queries;

    public SixthQueryHandler(IPredefinedQueries queries)
    {
        _queries = queries;
    }

    public async Task<Result<IEnumerable<SixthQueryResponse>>> Handle(SixthQuery request, CancellationToken cancellationToken)
    {
        var result = await _queries.SixthQuery();

        return Result.Create(result);
    }
}
