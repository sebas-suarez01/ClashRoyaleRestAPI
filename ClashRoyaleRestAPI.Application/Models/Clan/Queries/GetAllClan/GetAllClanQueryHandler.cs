using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClan;

internal class GetAllClanQueryHandler : GetAllModelQueryHandler<ClanModel, int>
{
    public GetAllClanQueryHandler(IClanRepository repository) : base(repository)
    {
    }
}
