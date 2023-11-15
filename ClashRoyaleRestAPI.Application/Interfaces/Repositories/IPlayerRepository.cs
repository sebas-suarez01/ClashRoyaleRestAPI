using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories;

public interface IPlayerRepository : IBaseRepository<PlayerModel, int>
{
    public Task<PageList<PlayerModel>> GetAllAsync(
        string? name, int? elo, string? sortColumn, string? sortOrder, int page, int pageSize);
    public Task<PlayerModel> GetSingleByIdAsync(int id, bool fullLoad = false);
    public Task<IEnumerable<PlayerModel>> GetPlayersByAliasAsync(string alias);
    public Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int playerId);
    public Task AddCard(int playerId, int cardId);
    public Task UpdateAlias(int playerId, string alias);
    public Task AddPlayerChallenge(int playerId, int challengeId);
    public Task AddPlayerChallengeResult(int playerId, int challengeId, int reward);
    public Task AddDonation(int playerId, int clanId, int cardId, int amount);

}
