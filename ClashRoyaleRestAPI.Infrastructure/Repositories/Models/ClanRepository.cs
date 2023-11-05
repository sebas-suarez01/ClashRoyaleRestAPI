using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models
{
    internal class ClanRepository : BaseRepository<ClanModel, int>, IClanRepository
    {
        private readonly IPlayerRepository _playerRepository;

        public ClanRepository(ClashRoyaleDbContext context, IPlayerRepository playerRepository) : base(context)
        {
            _playerRepository = playerRepository;
        }

        public async Task<ClanModel> GetSingleByIdAsync(int id, bool fullLoad = false)
        {
            var clan = fullLoad ? await _context.Clans
                                                .Include(c => c.Players)!
                                                .ThenInclude(p => p.Player)
                                                .Where(c => c.Id == id)
                                                .FirstOrDefaultAsync()
                                                ?? throw new IdNotFoundException<int>(id)
                                            :
                                             await base.GetSingleByIdAsync(id);


            return clan;
        }

        public async Task<int> Add(int playerId, ClanModel clan)
        {
            await Add(clan);

            var player = await _playerRepository.GetSingleByIdAsync(playerId);

            clan.AddPlayer(player!);

            await Save();

            return clan.Id;
        }

        public async Task<IEnumerable<ClanModel>> GetAllAvailable(int trophies)
        {
            return (await GetAllAsync()).Where(c => c.TypeOpen && c.MinTrophies < trophies);
        }

        public async Task<IEnumerable<ClanModel>> GetAllByName(string name)
        {
            return (await GetAllAsync()).Where(x => x.Name!.Contains(name));
        }

        public async Task AddPlayer(int clanId, int playerId, RankClan rank = RankClan.Member)
        {
            if (await ExistsClanPlayer(playerId, clanId))
                throw new DuplicationIdException(playerId, clanId);

            var clan = await GetSingleByIdAsync(clanId);

            var player = await _playerRepository.GetSingleByIdAsync(playerId);

            clan.AddPlayer(player);

            await Save();
        }

        public async Task RemovePlayer(int clanId, int playerId)
        {
            if (!await ExistsClanPlayer(playerId, clanId))
                throw new IdNotFoundException<int>(playerId, clanId);

            await _context.ClanPlayers
                .Include(cp => cp.Player)
                .Include(cp => cp.Clan)
                .Where(cp => cp.Player!.Id == playerId && cp.Clan!.Id == clanId)
                .ExecuteDeleteAsync();

            await Save();
        }

        public async Task UpdatePlayerRank(int clanId, int playerId, RankClan rank)
        {
            var playerClan = await _context.ClanPlayers.FindAsync(playerId, clanId)
                ?? throw new IdNotFoundException<int>(playerId, clanId);

            playerClan.UpdateRank(rank);

            _context.Entry(playerClan).State = EntityState.Modified;

            await Save();
        }

        public async Task<IEnumerable<ClanPlayersModel>> GetPlayers(int clanId)
        {
            var clan = await GetSingleByIdAsync(clanId, true);

            return clan.Players.ToList();
        }

        public async Task<bool> ExistsClanPlayer(int playerId, int clandId)
        {
            return await _context.ClanPlayers.FindAsync(playerId, clandId) is not null;
        }

    }
}
