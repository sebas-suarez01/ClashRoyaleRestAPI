using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories;

public interface IBattleRepository : IBaseRepository<BattleModel, BattleId>
{
    public Task<Guid> Add(PlayerId winnerId, PlayerId loserId, int AmountTrophies, int DurationInSeconds, DateTime Date);
}
