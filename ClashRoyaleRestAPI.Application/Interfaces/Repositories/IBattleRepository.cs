using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models.Battle.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories
{
    public interface IBattleRepository : IBaseRepository<BattleModel, BattleId>
    {
        public Task<BattleModel?> GetSingleByIdAsync(Guid id, bool fullLoad = false);
        public Task<Guid> Add(BattleModel battle, int winnerId, int loserId);
    }
}
