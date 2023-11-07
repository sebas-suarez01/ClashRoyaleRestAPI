using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Responses;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FirstQuery
{
    internal class FirstQueryHandler : IQueryHandler<FirstQuery, IEnumerable<FirstQueryResponse>>
    {
        private readonly IPredifinedQueries _queries;

        public FirstQueryHandler(IPredifinedQueries queries)
        {
            _queries = queries;
        }

        public async Task<Result<IEnumerable<FirstQueryResponse>>> Handle(FirstQuery request, CancellationToken cancellationToken)
        {
            var results = await _queries.FirstQuery();

            return Result.Success(results);
        }
    }
}
