using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands.AddChallenge;

internal class AddChallengeCommandHandler : AddModelCommandHandler<ChallengeModel, ChallengeId>
{
    public AddChallengeCommandHandler(IChallengeRepository repository) : base(repository)
    {
    }
}
