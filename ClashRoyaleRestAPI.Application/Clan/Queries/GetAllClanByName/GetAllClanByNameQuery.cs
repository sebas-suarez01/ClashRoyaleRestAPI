using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Clan;

namespace ClashRoyaleRestAPI.Application.Clan.Queries.GetAllClanByName
{
    public record GetAllClanByNameQuery(string Name) : IQuery<IEnumerable<ClanModel>>;
}
