using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands.UpdateChallenge;

internal class UpdateChallengeCommandHandler : UpdateModelCommandHandler<ChallengeModel, ChallengeId>
{
    public UpdateChallengeCommandHandler(IChallengeRepository repository) : base(repository)
    {
    }
}
