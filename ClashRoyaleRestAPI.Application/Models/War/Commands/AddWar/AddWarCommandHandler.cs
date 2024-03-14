using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddWar;

internal class AddWarCommandHandler : AddModelCommandHandler<WarModel, WarId>
{
    public AddWarCommandHandler(IWarRepository repository) : base(repository)
    {
    }
}
