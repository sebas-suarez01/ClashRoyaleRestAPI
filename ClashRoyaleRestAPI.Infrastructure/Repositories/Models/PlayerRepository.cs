using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using ClashRoyaleRestAPI.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models;

internal class PlayerRepository : BaseRepository<PlayerModel, int>, IPlayerRepository
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly ICardRepository _cardRepository;
    private readonly Lazy<IClanRepository> _clanRepository;

    public PlayerRepository(ClashRoyaleDbContext context,
                            IChallengeRepository challengeRepository,
                            ICardRepository cardRepository,
                            Lazy<IClanRepository> clanRepository) : base(context)
    {
        _challengeRepository = challengeRepository;
        _cardRepository = cardRepository;
        _clanRepository = clanRepository;
    }

    #region Interface Methods

    #region Queries

    public async Task<PageList<PlayerModel>> GetAllAsync(string? name,
                                                         int? elo,
                                                         string? sortColumn,
                                                         string? sortOrder,
                                                         int page,
                                                         int pageSize)
    {
        var players = _context.Players.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            players = players.Where(p => p.Alias!.Contains(name));
        }
        if (elo is not null)
        {
            players = players.Where(p => p.Elo > elo);
        }

        if (sortOrder?.ToLower() == "desc")
        {
            players = players.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            players = players.OrderBy(GetSortProperty(sortColumn));
        }

        await Task.CompletedTask;

        return PageList<PlayerModel>.Create(players, page, pageSize);
    }
    public async Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int playerId)
    {
        var player = await GetSingleByIdAsync(playerId, new GetPlayerByIdAsNoTrackingSpecification());

        await _context.Entry(player).Collection(p => p.Cards).LoadAsync();

        return player.Cards.Select(c => c.Card)!;
    }

    #endregion

    #region Commands
    public async Task AddCard(int playerId, int cardId)
    {
        var player = await GetSingleByIdAsync(playerId);

        await _context.Entry(player).Collection(p => p.Cards).LoadAsync();

        var card = await _cardRepository.GetSingleByIdAsync(cardId);

        if (await ExistsCollection(playerId, cardId))
            throw new DuplicationIdException(playerId, cardId);

        var collection = CollectionModel.Create(player, card, card.InitialLevel, DateTime.UtcNow);

        player.AddFavoriteCard(card);

        player.AddCard(collection);

        await Save();
    }

    public override async Task Delete(PlayerModel model)
    {
        await _context.Battles.Where(b => b.Loser.Id == model.Id).ExecuteDeleteAsync();

        _context.Remove(model);

        await Save();
    }

    public async Task UpdateAlias(int playerId, string alias)
    {
        var player = await GetSingleByIdAsync(playerId);

        player!.ChangeAlias(alias!);

        await Save();
    }

    public async Task AddPlayerChallenge(int playerId, int challengeId)
    {
        var challenge = await _challengeRepository.GetSingleByIdAsync(challengeId);

        if (!challenge!.IsOpen) throw new ChallengeClosedException();

        var player = await GetSingleByIdAsync(playerId);

        var playerChallenge = PlayerChallengesModel.Create(player!, challenge, 0);

        await _context.PlayerChallenges.AddAsync(playerChallenge);

        await Save();
    }
    public async Task AddPlayerChallengeResult(int playerId, int challengeId, int reward)
    {
        if (!await ExistsPlayerChallenge(playerId, challengeId))
            throw new IdNotFoundException<int>(playerId, challengeId);

        var playerChallenge = await _context.PlayerChallenges.FindAsync(playerId, challengeId);

        playerChallenge!.AddReward(reward);
        playerChallenge!.Completed();

        _context.Entry(playerChallenge).State = EntityState.Modified;

        await Save();
    }

    public async Task AddDonation(int playerId, int clanId, int cardId, int amount, DateTime date)
    {
        var player = await GetSingleByIdAsync(playerId);

        await _context.Entry(player).Collection(p => p.Cards).LoadAsync();


        var clan = await _clanRepository.Value.GetSingleByIdAsync(clanId);
        var card = await _cardRepository.GetSingleByIdAsync(cardId);

        if (!player!.HaveCard(cardId))
            throw new PlayerNotHaveCardException();

        if (!await ExistsClanPlayer(playerId, clanId))
            throw new IdNotFoundException<int>(playerId, clanId);

        if (await ExistsDonation(playerId, clanId, cardId, date))
            throw new DuplicationIdException(playerId, clanId, cardId);

        var donation = DonationModel.Create(player, clan!, card!, amount, date);

        await _context.Donations.AddAsync(donation);

        await Save();
    }

    #endregion

    #endregion

    #region Extra Methods

    public async Task<bool> ExistsCollection(int playerId, int cardId)
    {
        return await _context.Collection.FindAsync(playerId, cardId) is not null;
    }

    public async Task<bool> ExistsClanPlayer(int playerId, int clanId)
    {
        return await _context.ClanPlayers.FindAsync(playerId, clanId) is not null;
    }

    public async Task<bool> ExistsDonation(int playerId, int clanId, int cardId, DateTime date)
    {
        return await _context.Donations.FindAsync(playerId, clanId, cardId, date) is not null;
    }

    public async Task<bool> ExistsPlayerChallenge(int playerId, int challengeId)
    {
        return await _context.PlayerChallenges.FindAsync(playerId, challengeId) is not null;
    }

    private static Expression<Func<PlayerModel, object>> GetSortProperty(string? sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "elo" => player => player.Elo,
            "wins" => player => player.Victories,
            "name" => player => player.Alias!,
            _ => player => player.Id
        };
    }

    #endregion

}
