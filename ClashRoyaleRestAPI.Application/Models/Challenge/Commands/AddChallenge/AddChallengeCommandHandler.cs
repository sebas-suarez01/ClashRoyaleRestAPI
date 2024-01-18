using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Challenge.Commands.AddChallenge;

internal class AddChallengeCommandHandler : AddModelCommandHandler<ChallengeModel, int>
{
    public AddChallengeCommandHandler(IChallengeRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
