using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models.Battle.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Battle
{
    internal class GetBattleByIdSpecification : Specification<BattleModel>
    {
        public GetBattleByIdSpecification(Guid id) : base(battle => battle.Id == BattleId.Create(id))
        {
            AddInclude(q => q.Include(b => b.Winner!));
            AddInclude(q => q.Include(b => b.Loser!));
        }
    }
}
