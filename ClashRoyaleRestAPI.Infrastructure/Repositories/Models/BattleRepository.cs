using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models.Battle.ValueObjects;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models
{
    internal class BattleRepository : BaseRepository<BattleModel, BattleId>, IBattleRepository
    {
        private readonly IPlayerRepository _playerRepository;

        public BattleRepository(ClashRoyaleDbContext context, IPlayerRepository playerRepository) : base(context)
        {
            _playerRepository = playerRepository;
        }
        public async Task<Guid> Add(BattleModel battle, int winnerId, int loserId)
        {
            var winner = await _playerRepository.GetSingleByIdAsync(winnerId);
            var loser = await _playerRepository.GetSingleByIdAsync(loserId);

            battle = BattleModel.Create(battle.AmountTrophies, winner!, loser!, battle.DurationInSeconds);

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

        public async Task<BattleModel> GetSingleByIdAsync(Guid id, bool fullLoad = false)
        {
            var battle = fullLoad ? await _context.Battles
                                                .Include(c => c.Winner)
                                                .Include(c => c.Loser)
                                                .Where(c => c.Id == BattleId.Create(id))
                                                .FirstOrDefaultAsync()
                                                ?? throw new IdNotFoundException<Guid>(id)
                                            :
                                             await GetSingleByIdAsync(id);

            return battle!;
        }

    }
}
