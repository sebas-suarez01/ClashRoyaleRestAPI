using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Infrastructure.Common.CachedModels;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Cached;

internal class CachedClanRepository : IClanRepository
{
    private readonly ClanRepository _decorated;
    private readonly IDistributedCache _distributedCache;

    public CachedClanRepository(ClanRepository decorated, IDistributedCache cache)
    {
        _decorated = decorated;
        _distributedCache = cache;
    }

    public async Task<ClanModel> GetSingleByIdAsync(ClanId id)
    {
        var key = $"clanId-{id}";

        var cachedClanKey = await _distributedCache.GetStringAsync(key);

        ClanModel clan;
        if (string.IsNullOrEmpty(cachedClanKey))
        { 
            clan = await _decorated.GetSingleByIdAsync(id);

            var cachedModel = new CachedClanModel(clan.Id.Value, clan.Name, clan.Description, clan.Region,
                clan.TypeOpen, clan.AmountMembers, clan.TrophiesInWar, clan.MinTrophies);
            
            await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(cachedModel,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                }));

            return clan;
        }

        var cachedClanModel = JsonConvert.DeserializeObject<CachedClanModel>(cachedClanKey, new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        })!;

        clan = ClanModel.Create(cachedClanModel.Id, cachedClanModel.Name, cachedClanModel.Description,
            cachedClanModel.Region, cachedClanModel.TypeOpen, cachedClanModel.TrophiesInWar,
            cachedClanModel.MinTrophies);
        return clan;
    }

    public Task<ClanModel> GetSingleByIdAsync(ClanId id, Specification<ClanModel> specification)
    {
        return _decorated.GetSingleByIdAsync(id, specification);
    }

    public Task<PageList<ClanModel>> GetAllAsync(string? sortOrder, int page, int pageSize)
    {
        return _decorated.GetAllAsync(sortOrder, page, pageSize);
    }

    public Task<IEnumerable<ClanModel>> GetModelDataAsync(Specification<ClanModel> specification)
    {
        return _decorated.GetModelDataAsync(specification);
    }

    public Task<ClanId> Add(ClanModel model)
    {
        return _decorated.Add(model);
    }

    public Task Update(ClanModel model)
    {
        return _decorated.Update(model);
    }

    public Task Delete(ClanModel model)
    {
        return _decorated.Delete(model);
    }

    public Task<PageList<ClanModel>> GetAllAsync(string? name, string? region, int? minTrophies, int? trophiesInWar, bool? availables,
        string? sortColumn, string? sortOrder, int page, int pageSize)
    {
        return _decorated.GetAllAsync(name, region, minTrophies, trophiesInWar, availables, sortColumn, sortOrder, page,
            pageSize);
    }

    public async Task<IEnumerable<ClanModel>> GetAllByName(string name)
    {
        var key = $"clanId-{name}";

        var cachedClan = await _distributedCache.GetStringAsync(key);

        IEnumerable<ClanModel> clans;
        if (string.IsNullOrEmpty(cachedClan))
        { 
            clans = await _decorated.GetAllByName(name);

            await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(clans, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                }));

            return clans;
        }

        clans = JsonConvert.DeserializeObject<IEnumerable<ClanModel>>(cachedClan, new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        })!;

        return clans;
    }

    public Task<IEnumerable<ClanModel>> GetAllAvailable(int trophies)
    {
        return _decorated.GetAllAvailable(trophies);
    }

    public Task<IEnumerable<ClanPlayersModel>> GetPlayers(ClanId clanId)
    {
        return _decorated.GetPlayers(clanId);
    }

    public Task<ClanId> Add(PlayerId playerId, ClanModel clan)
    {
        return _decorated.Add(playerId, clan);
    }

    public Task AddPlayer(ClanId clanId, PlayerId playerId, RankClan rank = RankClan.Member)
    {
        return _decorated.AddPlayer(clanId, playerId, rank);
    }

    public Task RemovePlayer(ClanId clanId, PlayerId playerId)
    {
        return _decorated.RemovePlayer(clanId, playerId);
    }

    public Task UpdatePlayerRank(ClanId clanId, PlayerId playerId, RankClan rank)
    {
        return _decorated.RemovePlayer(clanId, playerId);
    }
}