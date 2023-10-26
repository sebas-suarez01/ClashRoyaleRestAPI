using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models
{
    public class ClanRepository : BaseRepository<ClanModel, int>, IClanRepository
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public ClanRepository(ClashRoyaleDbContext context, IPlayerRepository playerRepository, IMapper mapper) : base(context)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<ClanModel?> GetSingleByIdAsync(int id, bool fullLoad = false)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            ClanModel? clan = fullLoad ? _context.Clans?
                                                .Include(c => c.Players)!
                                                .ThenInclude(p => p.Player)
                                                .ProjectTo<ClanModel>(_mapper.ConfigurationProvider)
                                                .Where(c => c.Id == id)
                                                .FirstOrDefault()
                                            :
                                             await base.GetSingleByIdAsync(id);


            return clan;
        }

        public async Task<int> Add(int playerId, ClanModel clan)
        {
            await Add(clan);

            var player = await _playerRepository.GetSingleByIdAsync(playerId)
                ?? throw new IdNotFoundException();
            
            clan.AddPlayer(player);

            await Save();

            return clan.Id;
        }

        public async Task<IEnumerable<ClanModel>> GetAllAvailable(int trophies)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            return (await GetAllAsync()).Where(c => c.TypeOpen && c.MinTrophies < trophies);
        }

        public async Task<IEnumerable<ClanModel>> GetAllByName(string name)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            return (await GetAllAsync()).Where(x => x.Name!.Contains(name));
        }

        public async Task AddPlayer(int clanId, int playerId, RankClan rank = RankClan.Member)
        {
            ClanModel? clan = await GetSingleByIdAsync(clanId)
                ?? throw new IdNotFoundException();

            PlayerModel? player = await _playerRepository.GetSingleByIdAsync(playerId)
                ?? throw new IdNotFoundException();

            if (await ExistsClanPlayer(playerId, clanId))
                throw new DuplicationIdException();

            clan.AddPlayer(player);

            await Save();
        }

        public async Task RemovePlayer(int clanId, int playerId)
        {
            _ = await GetSingleByIdAsync(clanId)
                ?? throw new IdNotFoundException();

            _ = await _playerRepository.GetSingleByIdAsync(playerId)
                ?? throw new IdNotFoundException();

            ClanPlayersModel? playerClan = await _context.ClanPlayers
                                        .Include(pc => pc.Clan)
                                        .Include(pc => pc.Player)
                                        .Where(pc => pc.Player!.Id == playerId && pc.Clan!.Id == clanId)
                                        .FirstOrDefaultAsync()
                                        ?? throw new IdNotFoundException();


            _context.ClanPlayers.Remove(playerClan!);

            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlayerRank(int clanId, int playerId, RankClan rank)
        {
            _ = await GetSingleByIdAsync(clanId)
                ?? throw new IdNotFoundException();

            _ = await _playerRepository.GetSingleByIdAsync(playerId)
                ?? throw new IdNotFoundException();

            var playerClan = await _context.ClanPlayers.FindAsync(playerId, clanId)
            ?? throw new IdNotFoundException();

            playerClan.UpdateRank(rank);

            _context.Entry(playerClan).State = EntityState.Modified;

            await Save();
        }

        public async Task<IEnumerable<ClanPlayersModel>> GetPlayers(int clanId)
        {
            var clan = await GetSingleByIdAsync(clanId, true) ?? throw new IdNotFoundException();

            return clan.Players!.ToList();
        }

        public async Task<bool> ExistsClanPlayer(int playerId, int clandId)
        {
            return await _context.ClanPlayers.FindAsync(playerId, clandId) is not null;
        }

    }
}
