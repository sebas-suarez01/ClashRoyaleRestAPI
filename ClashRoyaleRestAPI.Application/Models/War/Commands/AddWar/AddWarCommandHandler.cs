using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddWar
{
    internal class AddWarCommandHandler : AddModelCommandHandler<WarModel, int>
    {
        public AddWarCommandHandler(IWarRepository repository) : base(repository)
        {
        }
    }
}
