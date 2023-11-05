using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayer
{
    internal class UpdatePlayerCommandHandler : UpdateModelCommandHandler<PlayerModel, int>
    {
        public UpdatePlayerCommandHandler(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
