using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models.Battle.ValueObjects;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Battle;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models;

internal class BattleRepository : BaseRepository<BattleModel, BattleId>, IBattleRepository
{
    private readonly IPlayerRepository _playerRepository;

    public BattleRepository(ClashRoyaleDbContext context, IPlayerRepository playerRepository) : base(context)
    {
        _playerRepository = playerRepository;
    }

    #region Interface Methods

    #region Queries
    public async Task<BattleModel> GetSingleByIdAsync(Guid id, bool fullLoad = false)
    {
        var battle = fullLoad ? await ApplySpecification(new GetBattleByIdSpecification(id))
                                            .FirstOrDefaultAsync()
                                            ?? throw new IdNotFoundException<Guid>(id)
                                        : await GetSingleByIdAsync(id);

        return battle!;
    }
    public override async Task<IEnumerable<BattleModel>> GetAllAsync()
    {
        return await ApplySpecification(new GetAllBattleSpecification())
                        .ToListAsync();
    }

    #endregion

    #region Commands
    public async Task<Guid> Add(BattleModel battle, int winnerId, int loserId)
    {
        var winner = await _playerRepository.GetSingleByIdAsync(winnerId);
        var loser = await _playerRepository.GetSingleByIdAsync(loserId);

        battle = BattleModel.Create(battle.AmountTrophies, winner!, loser!, battle.DurationInSeconds);

        _context.Battles.Add(battle);
        await Save();

        return battle.Id.Value;
    }
    #endregion

    #endregion

}
