using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

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

    public async Task<PlayerModel> GetSingleByIdAsync(int id, bool fullLoad = false)
    {

        var player = fullLoad ? await _context.Players
                                            .Include(p => p.FavoriteCard)?
                                            .Include(p => p.Cards)!
                                            .ThenInclude(c => c.Card)
                                            .Where(p => p.Id == id)
                                            .FirstOrDefaultAsync()!
                                            ?? throw new IdNotFoundException<int>(id)
                                        :
                                         await base.GetSingleByIdAsync(id);

        return player!;
    }

    public async Task AddCard(int playerId, int cardId)
    {
        var player = await GetSingleByIdAsync(playerId);

        var card = await _cardRepository.GetSingleByIdAsync(cardId);

        if (await ExistsCollection(playerId, cardId)) 
            throw new DuplicationIdException(playerId, cardId);

        var collection = CollectionModel.Create(player, card, card.InitialLevel, DateTime.UtcNow);

        player.AddCard(collection);

        await Save();
    }

    public async Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int playerId)
    {
        var player = await GetSingleByIdAsync(playerId, true);

        return player!.Cards?.Select(c => c.Card)!;
    }

    public async Task<IEnumerable<PlayerModel>> GetPlayersByAliasAsync(string alias)
    {
        return (await GetAllAsync()).Where(c => c.Alias == alias);
    }

    public async Task UpdateAlias(int playerId, string alias)
    {
        var player = await GetSingleByIdAsync(playerId);

        player!.ChangeAlias(alias!);

        await Save();
    }

    public async Task<bool> ExistsCollection(int playerId, int cardId)
    {
        return await _context.Collection.FindAsync(playerId, cardId) is not null;
    }

    public async Task AddChallengeResult(int playerId, int challengeId, int reward)
    {
        var player = await GetSingleByIdAsync(playerId);

        var challenge = await _challengeRepository.GetSingleByIdAsync(challengeId);

        if (!challenge!.IsOpen) throw new ChallengeClosedException();

        var challengePlayerResult = ChallengePlayersModel.Create(player!, challenge, reward);

        await _context.ChallengePlayers.AddAsync(challengePlayerResult);
        await Save();
    }

    public async Task<bool> ExistsClanPlayer(int playerId, int clanId)
    {
        return await _context.ClanPlayers.FindAsync(playerId, clanId) is not null;
    }

    public async Task AddDonation(int playerId, int clanId, int cardId, int amount)
    {
        var player = await GetSingleByIdAsync(playerId);
        var clan = await _clanRepository.Value.GetSingleByIdAsync(clanId);
        var card = await _cardRepository.GetSingleByIdAsync(cardId);

        if (!player!.HaveCard(cardId)) throw new PlayerNotHaveCardException();

        if (!await ExistsClanPlayer(playerId, clanId)) throw new IdNotFoundException<int>(playerId, clanId);

        var donation = DonationModel.Create(player, clan!, card!, amount);

        await _context.Donations.AddAsync(donation);

        await Save();
    }
}
