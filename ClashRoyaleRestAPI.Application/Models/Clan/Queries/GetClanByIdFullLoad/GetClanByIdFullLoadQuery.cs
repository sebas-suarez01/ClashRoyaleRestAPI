using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanByIdFullLoad
{
    public record GetClanByIdFullLoadQuery(int Id, bool FullLoad) : IQuery<ClanModel>;
}
