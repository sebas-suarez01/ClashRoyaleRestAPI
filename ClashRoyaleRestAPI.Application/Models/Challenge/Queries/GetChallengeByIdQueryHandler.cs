using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Queries
{
    internal class GetChallengeByIdQueryHandler : GetModelByIdQueryHandler<ChallengeModel, int>
    {
        public GetChallengeByIdQueryHandler(IChallengeRepository repository) : base(repository)
        {
        }
    }
}
