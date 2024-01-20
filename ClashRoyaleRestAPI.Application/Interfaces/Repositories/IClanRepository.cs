using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories;

public interface IClanRepository : IBaseRepository<ClanModel, ClanId>
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
    public Task<IEnumerable<ClanPlayersModel>> GetPlayers(ClanId clanId);
    public Task<ClanId> Add(PlayerId playerId, ClanModel clan);
    public Task AddPlayer(ClanId clanId, PlayerId playerId, RankClan rank = RankClan.Member);
    public Task RemovePlayer(ClanId clanId, PlayerId playerId);
    public Task UpdatePlayerRank(ClanId clanId, PlayerId playerId, RankClan rank);
}
