using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdateClan;

internal class UpdateClanCommandHandler : UpdateModelCommandHandler<ClanModel, int>
{
    public UpdateClanCommandHandler(IClanRepository repository) : base(repository)
    {
    }
}
