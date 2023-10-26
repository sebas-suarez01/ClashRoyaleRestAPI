using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands
{
    public class DeletePlayerCommandHandler : DeleteModelCommandHandler<PlayerModel, int>
    {
        public DeletePlayerCommandHandler(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
