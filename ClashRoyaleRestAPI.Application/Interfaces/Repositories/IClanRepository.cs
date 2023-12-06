using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories;

public interface IClanRepository : IBaseRepository<ClanModel, int>
{
    public Task<PageList<ClanModel>> GetAllAsync(string? name,
                                                    string? region,
                                                    int? minTrophies,
                                                    int? trophiesInWar,
                                                    bool? availables,
                                                    string? sortColumn,
                                                    string? sortOrder,
                                                    int page,
                                                    int pageSize);
    public Task<IEnumerable<ClanModel>> GetAllByName(string name);
    public Task<IEnumerable<ClanModel>> GetAllAvailable(int trophies);
    public Task<IEnumerable<ClanPlayersModel>> GetPlayers(int clanId);
    public Task<int> Add(int playerId, ClanModel clan);
    public Task AddPlayer(int clanId, int playerId, RankClan rank = RankClan.Member);
    public Task RemovePlayer(int clanId, int playerId);
    public Task UpdatePlayerRank(int clanId, int playerId, RankClan rank);
}
