using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.DeletePlayer;

internal class DeletePlayerCommandHandler : DeleteModelCommandHandler<PlayerModel, PlayerId>
{
    public DeletePlayerCommandHandler(IPlayerRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
