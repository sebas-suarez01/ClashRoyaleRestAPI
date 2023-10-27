using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayer
{
    public class UpdatePlayerCommandHandler : UpdateModelCommandHandler<PlayerModel, int>
    {
        public UpdatePlayerCommandHandler(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
