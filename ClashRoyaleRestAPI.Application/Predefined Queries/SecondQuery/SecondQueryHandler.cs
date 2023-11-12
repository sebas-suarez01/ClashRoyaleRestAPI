using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.SecondQuery
{
    internal class SecondQueryHandler : IQueryHandler<SecondQuery, IEnumerable<SecondQueryResponse>>
    {
        private readonly IPredefinedQueries _queries;

        public SecondQueryHandler(IPredefinedQueries queries)
        {
            _queries = queries;
        }

        public async Task<Result<IEnumerable<SecondQueryResponse>>> Handle(SecondQuery request, CancellationToken cancellationToken)
        {
            var clans = await _queries.SecondQuery();

            return Result.Create(clans);
        }
    }
}
