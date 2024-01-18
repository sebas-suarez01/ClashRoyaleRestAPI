using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands.UpdateChallenge;

internal class UpdateChallengeCommandHandler : UpdateModelCommandHandler<ChallengeModel, int>
{
    public UpdateChallengeCommandHandler(IChallengeRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
