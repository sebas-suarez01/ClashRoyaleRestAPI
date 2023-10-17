using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models.Battle.ValueObjects;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (await _playerRepository.ExistsId(winnerId)) ;// throw new IdNotFoundException<PlayerModel, int>(winnerId);
            if (await _playerRepository.ExistsId(loserId)); //throw new IdNotFoundException<PlayerModel, int>(loserId);

            var winner = await _playerRepository.GetSingleByIdAsync(winnerId);
            var loser = await _playerRepository.GetSingleByIdAsync(loserId);

            battle.Winner = winner;
            battle.Loser = loser;

            _context.Battles.Add(battle);
            await Save();

            return battle.Id.Value;
        }

        public override async Task<IEnumerable<BattleModel?>> GetAllAsync()
        {
            return await _context.Battles
                            .Include(b => b.Winner)
                            .Include(b => b.Loser)
                            .ToListAsync();
        }

        public async Task<BattleModel> GetSingleByIdAsync(Guid id, bool fullLoad = false)
        {
            BattleModel? battle = fullLoad ? _context.Battles
                                                .Include(c => c.Winner)
                                                .Where(c => c.Id == BattleId.Create(id))
                                                .First()
                                            :
                                             await GetSingleByIdAsync(id);

            return battle;
        }

    }
}
