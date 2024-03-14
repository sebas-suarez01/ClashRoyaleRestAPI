using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.DeletePlayer;

internal class DeletePlayerCommandHandler : DeleteModelCommandHandler<PlayerModel, PlayerId>
{
    public DeletePlayerCommandHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
