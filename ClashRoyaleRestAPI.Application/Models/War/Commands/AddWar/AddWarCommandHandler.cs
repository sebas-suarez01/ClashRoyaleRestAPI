using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddWar;

internal class AddWarCommandHandler : AddModelCommandHandler<WarModel, WarId>
{
    public AddWarCommandHandler(IWarRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
