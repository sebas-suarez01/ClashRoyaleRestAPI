using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands
{
    public class DeleteWarCommandHandler : DeleteModelCommandHandler<WarModel, int>
    {
        public DeleteWarCommandHandler(IWarRepository repository) : base(repository)
        {
        }
    }
}
