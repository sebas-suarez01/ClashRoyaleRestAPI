using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.ThirdQuery
{
    internal class ThirdQueryHandler : IQueryHandler<ThirdQuery, IEnumerable<ThirdQueryResponse>>
    {
        private readonly IPredefinedQueries _queries;

        public ThirdQueryHandler(IPredefinedQueries queries)
        {
            _queries = queries;
        }

        public async Task<Result<IEnumerable<ThirdQueryResponse>>> Handle(ThirdQuery request, CancellationToken cancellationToken)
        {
            var result = await _queries.ThirdQuery();

            return Result.Create(result);
        }
    }
}
