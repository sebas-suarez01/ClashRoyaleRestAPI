using ClashRoyaleRestAPI.Application.Common.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.War;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands
{
    public class AddWarCommandHandler : AddModelCommandHandler<WarModel, int>
    {
        public AddWarCommandHandler(IWarRepository repository) : base(repository)
        {
        }
    }
}
