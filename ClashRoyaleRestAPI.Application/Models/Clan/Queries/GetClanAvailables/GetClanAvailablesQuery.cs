using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Clan;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanAvailables
{
    public record GetClanAvailablesQuery(int Trophies) : IQuery<IEnumerable<ClanModel>>;
}
