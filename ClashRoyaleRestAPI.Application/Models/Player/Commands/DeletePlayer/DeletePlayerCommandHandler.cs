using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.DeletePlayer
{
    public class DeletePlayerCommandHandler : DeleteModelCommandHandler<PlayerModel, int>
    {
        public DeletePlayerCommandHandler(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
