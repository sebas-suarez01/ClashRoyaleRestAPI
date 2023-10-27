using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Queries.GetAllOpen
{
    public class GetAllOpenChallengeQueryHandler : IQueryHandler<GetAllOpenChallengeQuery, IEnumerable<ChallengeModel>>
    {
        private readonly IChallengeRepository _challengeRepository;

        public GetAllOpenChallengeQueryHandler(IChallengeRepository challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }

        public async Task<Result<IEnumerable<ChallengeModel>>> Handle(GetAllOpenChallengeQuery request, CancellationToken cancellationToken)
        {
            var challenges = await _challengeRepository.GetAllOpenChallenges();
            return Result.Create(challenges);
        }
    }
}
