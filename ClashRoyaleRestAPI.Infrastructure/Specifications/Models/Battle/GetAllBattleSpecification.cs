using ClashRoyaleRestAPI.Domain.Models.Battle;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Battle
{
    internal class GetAllBattleSpecification : Specification<BattleModel>
    {
        public GetAllBattleSpecification() : base(null!)
        {
            AddInclude(q => q.Include(b => b.Winner!));
            AddInclude(q => q.Include(b => b.Loser!));
        }
    }
}
