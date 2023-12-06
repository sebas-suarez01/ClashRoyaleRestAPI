using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands.DeleteChallenge;

internal class DeleteChallengeCommandHandler : DeleteModelCommandHandler<ChallengeModel, int>
{
    public DeleteChallengeCommandHandler(IChallengeRepository repository) : base(repository)
    {
    }
}
