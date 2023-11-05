using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.DeletePlayer
{
    internal class DeletePlayerCommandHandler : DeleteModelCommandHandler<PlayerModel, int>
    {
        public DeletePlayerCommandHandler(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
