using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayer;

internal class AddPlayerCommandHandler : AddModelCommandHandler<PlayerModel, PlayerId>
{
    public AddPlayerCommandHandler(IPlayerRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
