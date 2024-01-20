using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClan;

internal class GetAllClanQueryHandler : GetAllModelQueryHandler<ClanModel, ClanId>
{
    public GetAllClanQueryHandler(IClanRepository repository) : base(repository)
    {
    }
}
