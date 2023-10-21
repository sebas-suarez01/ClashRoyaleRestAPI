using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models.Battle.ValueObjects;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories
{
    public class BattleRepository : BaseRepository<BattleModel, BattleId>, IBattleRepository
    {
        private readonly IPlayerRepository _playerRepository;

        public BattleRepository(ClashRoyaleDbContext context, IPlayerRepository playerRepository) : base(context)
        {
            _playerRepository = playerRepository;
        }
        public async Task<Guid> Add(BattleModel battle, int winnerId, int loserId)
        {
            if (!await _playerRepository.ExistsId(winnerId)) throw new IdNotFoundException();
            if (!await _playerRepository.ExistsId(loserId)) throw new IdNotFoundException();

            var winner = await _playerRepository.GetSingleByIdAsync(winnerId);
            var loser = await _playerRepository.GetSingleByIdAsync(loserId);

            battle.Winner = winner;
            battle.Loser = loser;

            battle.GetId();

            _context.Battles.Add(battle);
            await Save();

            return battle.Id.Value;
        }

        public override async Task<IEnumerable<BattleModel>> GetAllAsync()
        {
            return await _context.Battles
                            .Include(b => b.Winner)
                            .Include(b => b.Loser)
                            .ToListAsync();
        }

        public async Task<BattleModel?> GetSingleByIdAsync(Guid id, bool fullLoad = false)
        {
            BattleModel? battle = fullLoad ? _context.Battles
                                                .Include(c => c.Winner)
                                                .Include(c => c.Loser)
                                                .Where(c => c.Id == BattleId.Create(id))
                                                .FirstOrDefault()
                                            :
                                             await GetSingleByIdAsync(id);

            return battle;
        }

    }
}
