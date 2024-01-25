using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayer;

internal class UpdatePlayerCommandHandler : UpdateModelCommandHandler<PlayerModel, PlayerId>
{
    public UpdatePlayerCommandHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
