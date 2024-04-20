using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Cached;

internal class CachedPlayerRepository : IPlayerRepository
{
    private readonly PlayerRepository _decorated;
    private readonly IMemoryCache _memoryCache;

    public CachedPlayerRepository(PlayerRepository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;
    }

    public Task<PlayerModel> GetSingleByIdAsync(PlayerId id)
    {
        string key = $"{nameof(PlayerModel)}-Id:{id.Value}";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(3));

                return  _decorated.GetSingleByIdAsync(id);
            })!;
    }

    public Task<PlayerModel> GetSingleByIdAsync(PlayerId id, Specification<PlayerModel> specification)
    {
        string key = $"{nameof(PlayerModel)}-Id:{id.Value}";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                return  _decorated.GetSingleByIdAsync(id, specification);
            })!;
    }

    public Task<PageList<PlayerModel>> GetAllAsync(string? sortOrder, int page, int pageSize)
    {
        string key = $"{nameof(PlayerModel)}-AllPlayersPagination";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                return  _decorated.GetAllAsync(sortOrder, page, pageSize);
            })!;
    }

    public Task<IEnumerable<PlayerModel>> GetModelDataAsync(Specification<PlayerModel> specification)
    {
        string key = $"{nameof(PlayerModel)}-DataSpecification";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

                return  _decorated.GetModelDataAsync(specification);
            })!;
    }

    public Task<PlayerId> Add(PlayerModel model)
    {
        return _decorated.Add(model);
    }

    public Task Update(PlayerModel model)
    {
        return _decorated.Update(model);
    }

    public Task Delete(PlayerModel model)
    {
        return _decorated.Delete(model);
    }

    public Task<PageList<PlayerModel>> GetAllAsync(string? name, int? elo, string? sortColumn, string? sortOrder, int page, int pageSize)
    {
        string key = $"{nameof(PlayerModel)}-AllPlayersSortingPagination";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

                return  _decorated.GetAllAsync(name, elo, sortColumn, sortOrder, page, pageSize);
            })!;
    }

    public Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(PlayerId playerId)
    {
        string key = $"{nameof(PlayerModel)}-Id:{playerId.Value}";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

                return  _decorated.GetAllCardsOfPlayerAsync(playerId);
            })!;
    }

    public Task AddCard(PlayerId playerId, int cardId)
    {
        return _decorated.AddCard(playerId, cardId);
    }

    public Task UpdateAlias(PlayerId playerId, string alias)
    {
        return _decorated.UpdateAlias(playerId, alias);
    }

    public Task AddPlayerChallenge(PlayerId playerId, ChallengeId challengeId)
    {
        return _decorated.AddPlayerChallenge(playerId, challengeId);
    }

    public Task AddPlayerChallengeResult(PlayerId playerId, ChallengeId challengeId, int reward)
    {
        return _decorated.AddPlayerChallengeResult(playerId, challengeId, reward);
    }

    public Task AddDonation(PlayerId playerId, ClanId clanId, int cardId, int amount, DateTime date)
    {
        return _decorated.AddDonation(playerId, clanId, cardId, amount, date);
    }
}