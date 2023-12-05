using ClashRoyaleRestAPI.Domain.Models.Battle;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.Battle
{
    public class GetAllBattleSpecification : Specification<BattleModel>
    {
        public GetAllBattleSpecification() : base(null!)
        {
            AddInclude(q => q.Include(b => b.Winner!));
            AddInclude(q => q.Include(b => b.Loser!));

            AsNoTracking = true;
            IsSplitQuery = true;
        }
    }
}
