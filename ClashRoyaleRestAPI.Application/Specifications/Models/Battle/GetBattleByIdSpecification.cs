using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.Battle;

public class GetBattleByIdSpecification : Specification<BattleModel>
{
    public GetBattleByIdSpecification(BattleId id) : base(battle => battle.Id == id)
    {
        AddInclude(q => q.Include(b => b.Winner!));
        AddInclude(q => q.Include(b => b.Loser!));
    }
}
