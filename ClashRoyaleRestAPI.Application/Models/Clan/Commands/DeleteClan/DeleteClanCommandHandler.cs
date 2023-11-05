using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.DeleteClan
{
    internal class DeleteClanCommandHandler : DeleteModelCommandHandler<ClanModel, int>
    {
        public DeleteClanCommandHandler(IClanRepository repository) : base(repository)
        {
        }
    }
}
