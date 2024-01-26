using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using ClashRoyaleRestAPI.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models;

internal class PlayerRepository : BaseRepository<PlayerModel, PlayerId>, IPlayerRepository
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
    public async Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(PlayerId playerId)
    {
        var player = await GetSingleByIdAsync(playerId, new GetPlayerByIdAsNoTrackingSpecification(playerId));

        await _context.Entry(player).Collection(p => p.Cards).LoadAsync();

        return player.Cards.Select(c => c.Card)!;
    }

    #endregion

    #region Commands
    public async Task AddCard(PlayerId playerId, int cardId)
    {
        var player = await GetSingleByIdAsync(playerId);

        await _context.Entry(player).Collection(p => p.Cards).LoadAsync();

        var card = await _cardRepository.GetSingleByIdAsync(cardId);

        if (await ExistsCollection(playerId, cardId))
            throw new DuplicationIdException<string>(playerId.ToString(), cardId.ToString());

        var collection = CollectionModel.Create(player, card, card.InitialLevel, DateTime.UtcNow);

        player.AddFavoriteCard(card);

        player.AddCard(collection);
    }

    public override async Task Delete(PlayerModel model)
    {
        await _context.Battles.Where(b => b.Loser!.Id == model.Id).ExecuteDeleteAsync();

        _context.Remove(model);
    }

    public async Task UpdateAlias(PlayerId playerId, string alias)
    {
        var player = await GetSingleByIdAsync(playerId);

        player!.ChangeAlias(alias!);
    }

    public async Task AddPlayerChallenge(PlayerId playerId, ChallengeId challengeId)
    {
        var challenge = await _challengeRepository.GetSingleByIdAsync(challengeId);

        if (!challenge!.IsOpen) throw new ChallengeClosedException();

        var player = await GetSingleByIdAsync(playerId);

        var playerChallenge = PlayerChallengesModel.Create(player!, challenge, 0);

        await _context.PlayerChallenges.AddAsync(playerChallenge);
    }
    
    public async Task AddPlayerChallengeResult(PlayerId playerId, ChallengeId challengeId, int reward)
    {
        if (!await ExistsPlayerChallenge(playerId, challengeId))
            throw new IdNotFoundException<string>(playerId.ToString(), challengeId.ToString());

        var playerChallenge = await _context
                .PlayerChallenges
                .SingleAsync(pc=> pc.Player!.Id == playerId && pc.Challenge!.Id ==challengeId);
        
        playerChallenge!.AddReward(reward);
        playerChallenge!.Completed();

        _context.Entry(playerChallenge).State = EntityState.Modified;
    }

    public async Task AddDonation(PlayerId playerId, ClanId clanId, int cardId, int amount, DateTime date)
    {
        var player = await GetSingleByIdAsync(playerId);

        await _context.Entry(player).Collection(p => p.Cards).LoadAsync();


        var clan = await _clanRepository.Value.GetSingleByIdAsync(clanId);
        var card = await _cardRepository.GetSingleByIdAsync(cardId);

        if (!player!.HaveCard(cardId))
            throw new PlayerNotHaveCardException();

        if (!await ExistsClanPlayer(playerId, clanId))
            throw new IdNotFoundException<string>(playerId.ToString(), clanId.ToString());

        if (await ExistsDonation(playerId, clanId, cardId, date))
            throw new DuplicationIdException<string>(playerId.ToString(), clanId.ToString(), cardId.ToString());

        var donation = DonationModel.Create(player, clan!, card!, amount, date);

        await _context.Donations.AddAsync(donation);
    }

    #endregion

    #endregion

    #region Extra Methods

    private async Task<bool> ExistsCollection(PlayerId playerId, int cardId)
    {
        return await _context
            .Collection
            .AsNoTracking()
            .SingleOrDefaultAsync(cp => cp.Card.Id == cardId && cp.Player.Id == playerId) is not null;
    }

    private async Task<bool> ExistsClanPlayer(PlayerId playerId, ClanId clanId)
    {
        return await _context
            .ClanPlayers
            .AsNoTracking()
            .SingleOrDefaultAsync(cp => cp.Clan.Id == clanId && cp.Player.Id == playerId) is not null;
    }

    private async Task<bool> ExistsDonation(PlayerId playerId, ClanId clanId, int cardId, DateTime date)
    {
        return await _context
            .Donations
            .AsNoTracking()
            .SingleOrDefaultAsync(cp => cp.Player.Id == playerId && 
                                        cp.Clan.Id == clanId && 
                                        cp.Card.Id == cardId && 
                                        cp.Date == date) is not null;
    }

    private async Task<bool> ExistsPlayerChallenge(PlayerId playerId, ChallengeId challengeId)
    {
        return await _context
            .PlayerChallenges
            .SingleOrDefaultAsync(cp => cp.Challenge!.Id == challengeId && cp.Player!.Id == playerId) is not null;
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
