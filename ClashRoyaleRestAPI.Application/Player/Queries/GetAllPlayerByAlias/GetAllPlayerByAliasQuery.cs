using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Application.Player.Queries.GetAllPlayerByAlias
{
    public record GetAllPlayerByAliasQuery(string Alias) : IQuery<IEnumerable<PlayerModel>>;
}
