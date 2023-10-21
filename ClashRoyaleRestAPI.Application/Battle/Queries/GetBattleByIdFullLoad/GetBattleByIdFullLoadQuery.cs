using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Battle;

namespace ClashRoyaleRestAPI.Application.Battle.Queries.GetBattleByIdFullLoad
{
    public record GetBattleByIdFullLoadQuery(Guid Id, bool FullLoad) : IQuery<BattleModel>;
}
