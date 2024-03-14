using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Queries.GetChallengeById;

internal class GetChallengeByIdQueryHandler : GetModelByIdQueryHandler<ChallengeModel, ChallengeId>
{
    public GetChallengeByIdQueryHandler(IChallengeRepository repository) : base(repository)
    {
    }
}
