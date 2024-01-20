using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands.DeleteChallenge;

internal class DeleteChallengeCommandHandler : DeleteModelCommandHandler<ChallengeModel, ChallengeId>
{
    public DeleteChallengeCommandHandler(IChallengeRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
