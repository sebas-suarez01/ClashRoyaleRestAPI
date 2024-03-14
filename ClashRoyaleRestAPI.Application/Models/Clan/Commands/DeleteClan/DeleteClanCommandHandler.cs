using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.DeleteClan;

internal class DeleteClanCommandHandler : DeleteModelCommandHandler<ClanModel, ClanId>
{
    public DeleteClanCommandHandler(IClanRepository repository) : base(repository)
    {
    }
}
