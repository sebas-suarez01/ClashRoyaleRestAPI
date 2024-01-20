using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories;

public interface IBattleRepository : IBaseRepository<BattleModel, BattleId>
{
    public Task<Guid> Add(BattleModel battle, PlayerId winnerId, PlayerId loserId);
}
