using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdateClan
{
    public class UpdateClanCommandHandler : UpdateModelCommandHandler<ClanModel, int>
    {
        public UpdateClanCommandHandler(IClanRepository repository) : base(repository)
        {
        }
    }
}
