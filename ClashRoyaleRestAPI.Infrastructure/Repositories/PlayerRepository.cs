using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories
{
    public class PlayerRepository : BaseRepository<PlayerModel, int>, IPlayerRepository
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public PlayerRepository(ClashRoyaleDbContext context, ICardRepository cardRepository, IMapper mapper) : base(context)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<PlayerModel?> GetSingleByIdAsync(int id, bool fullLoad = false)
        {

            PlayerModel? player = fullLoad ? _context.Players?
                                                .Include(p => p.FavoriteCard)?
                                                .Include(p => p.Cards)!
                                                .ThenInclude(c => c.Card)
                                                .ProjectTo<PlayerModel>(_mapper.ConfigurationProvider)
                                                .Where(p => p.Id == id)
                                                .First()
                                            :
                                             await base.GetSingleByIdAsync(id);

            return player;
        }

        public async Task AddCard(int playerId, int cardId)
        {
            var player = await GetSingleByIdAsync(playerId) ?? throw new IdNotFoundException();

            var card = await _cardRepository.GetSingleByIdAsync(cardId) ?? throw new IdNotFoundException();

            if (await ExistsCollection(playerId, cardId)) throw new DuplicationIdException();

            player!.Cards ??= new List<CollectionModel>();

            var collect = CollectionModel.Create(player, card, card.InitialLevel, DateTime.UtcNow);

            await _context.Collection.AddAsync(collect);

            await Save();
        }

        public async Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int playerId)
        {
            PlayerModel player = await GetSingleByIdAsync(playerId, true) ?? throw new IdNotFoundException();

            return player.Cards?.Select(c => c.Card)!;
        }

        public async Task<IEnumerable<PlayerModel>> GetPlayersByAliasAsync(string alias)
        {
            return (await GetAllAsync()).Where(c => c.Alias == alias);
        }

        public async Task UpdateAlias(int playerId, string alias)
        {
            var player = await GetSingleByIdAsync(playerId) ?? throw new IdNotFoundException();
            player.Alias = alias;

            await Save();
        }

        public async Task<bool> ExistsCollection(int playerId, int cardId)
        {
            return (await _context.Collection.FindAsync(playerId, cardId)) is not null;
        }
    }
}
