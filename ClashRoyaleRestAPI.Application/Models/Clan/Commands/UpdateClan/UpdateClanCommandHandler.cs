using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdateClan;

internal class UpdateClanCommandHandler : UpdateModelCommandHandler<ClanModel, ClanId>
{
    public UpdateClanCommandHandler(IClanRepository repository) : base(repository)
    {
    }
}
