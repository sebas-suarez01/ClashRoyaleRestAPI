using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayer
{
    internal class AddPlayerCommandHandler : AddModelCommandHandler<PlayerModel, int>
    {
        public AddPlayerCommandHandler(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
