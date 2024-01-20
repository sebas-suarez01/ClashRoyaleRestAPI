using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.DeleteWar;

internal class DeleteWarCommandHandler : DeleteModelCommandHandler<WarModel, WarId>
{
    public DeleteWarCommandHandler(IWarRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
