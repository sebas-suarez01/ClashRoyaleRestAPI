using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FifthQuery;

internal class FifthQueryHandler : IQueryHandler<FifthQuery, IEnumerable<FifthQueryResponse>>
{
    public Task<Result<IEnumerable<FifthQueryResponse>>> Handle(FifthQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
