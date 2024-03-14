using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayer;

internal class AddPlayerCommandHandler : AddModelCommandHandler<PlayerModel, PlayerId>
{
    public AddPlayerCommandHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
