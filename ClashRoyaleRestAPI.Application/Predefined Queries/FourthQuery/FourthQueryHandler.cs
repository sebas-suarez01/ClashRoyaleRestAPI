using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FourthQuery
{
    internal class FourthQueryHandler : IQueryHandler<FourthQuery, IEnumerable<FourthQueryResponse>>
    {
        private readonly IPredefinedQueries _queries;

        public FourthQueryHandler(IPredefinedQueries queries)
        {
            _queries = queries;
        }

        public async Task<Result<IEnumerable<FourthQueryResponse>>> Handle(FourthQuery request, CancellationToken cancellationToken)
        {
            var result = await _queries.FourthQuery();

            return Result.Create(result);
        }
    }
}
