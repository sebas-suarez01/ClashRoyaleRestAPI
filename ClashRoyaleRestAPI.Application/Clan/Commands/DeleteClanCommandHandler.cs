using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Clan;

namespace ClashRoyaleRestAPI.Application.Clan.Commands
{
    public class DeleteClanCommandHandler : DeleteModelCommandHandler<ClanModel, int>
    {
        public DeleteClanCommandHandler(IClanRepository repository) : base(repository)
        {
        }
    }
}
