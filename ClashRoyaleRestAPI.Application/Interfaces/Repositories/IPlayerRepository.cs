using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories;

public interface IPlayerRepository : IBaseRepository<PlayerModel, PlayerId>
{
    public Task<PageList<PlayerModel>> GetAllAsync(
        string? name, int? elo, string? sortColumn, string? sortOrder, int page, int pageSize);
    public Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(PlayerId playerId);
    public Task AddCard(PlayerId playerId, int cardId);
    public Task UpdateAlias(PlayerId playerId, string alias);
    public Task AddPlayerChallenge(PlayerId playerId, ChallengeId challengeId);
    public Task AddPlayerChallengeResult(PlayerId playerId, ChallengeId challengeId, int reward);
    public Task AddDonation(PlayerId playerId, ClanId clanId, int cardId, int amount, DateTime date);

}
