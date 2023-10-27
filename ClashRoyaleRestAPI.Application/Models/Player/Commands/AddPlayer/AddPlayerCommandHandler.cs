using ClashRoyaleRestAPI.Application.Common.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayer
{
    public class AddPlayerCommandHandler : AddModelCommandHandler<PlayerModel, int>
    {
        public AddPlayerCommandHandler(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
