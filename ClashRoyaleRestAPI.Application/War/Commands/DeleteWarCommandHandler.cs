using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.War;

namespace ClashRoyaleRestAPI.Application.War.Commands
{
    public class DeleteWarCommandHandler : DeleteModelCommandHandler<WarModel, int>
    {
        public DeleteWarCommandHandler(IWarRepository repository) : base(repository)
        {
        }
    }
}
