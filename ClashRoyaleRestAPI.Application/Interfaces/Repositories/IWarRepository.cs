using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories;

public interface IWarRepository : IBaseRepository<WarModel, WarId>
{
    public Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date);
    public Task AddClanToWar(WarId warId, ClanId clanId, int prize);
}
