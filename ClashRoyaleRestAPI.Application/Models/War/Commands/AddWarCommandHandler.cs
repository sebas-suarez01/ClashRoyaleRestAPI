using ClashRoyaleRestAPI.Application.Common.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands
{
    internal class AddWarCommandHandler : AddModelCommandHandler<WarModel, int>
    {
        public AddWarCommandHandler(IWarRepository repository) : base(repository)
        {
        }
    }
}
