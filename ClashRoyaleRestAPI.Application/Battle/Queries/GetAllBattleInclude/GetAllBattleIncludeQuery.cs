using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Battle;

namespace ClashRoyaleRestAPI.Application.Battle.Queries.GetAllBattleInclude
{
    public record GetAllBattleIncludeQuery() : IQuery<IEnumerable<BattleModel>>;
}
