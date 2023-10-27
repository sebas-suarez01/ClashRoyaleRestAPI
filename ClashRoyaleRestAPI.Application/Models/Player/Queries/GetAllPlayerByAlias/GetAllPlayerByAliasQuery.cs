using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerByAlias
{
    public record GetAllPlayerByAliasQuery(string Alias) : IQuery<IEnumerable<PlayerModel>>;
}
