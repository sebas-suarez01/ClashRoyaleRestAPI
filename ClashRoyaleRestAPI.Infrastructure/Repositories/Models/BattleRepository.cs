using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications.Models.Battle;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models.Battle.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
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
    public override async Task<PageList<BattleModel>> GetAllAsync(string? sortOrder, int page, int pageSize)
    {
        await Task.CompletedTask;

        var battles = ApplySpecification(new GetAllBattleSpecification());

        if (sortOrder?.ToLower() == "desc")
        {
            battles = battles.OrderByDescending(q => q.Id.Value);
        }

        return PageList<BattleModel>.Create(battles, page, pageSize);
    }

    #endregion

    #region Commands
    public async Task<Guid> Add(BattleModel battle, int winnerId, int loserId)
    {
        if (await ExistsBattleIndex(winnerId, loserId, battle.Date))
            throw new DuplicationIndexException(string.Join(",", winnerId, loserId, battle.Date));

        var winner = await _playerRepository.GetSingleByIdAsync(winnerId);
        var loser = await _playerRepository.GetSingleByIdAsync(loserId);

        battle = BattleModel.Create(battle.AmountTrophies, winner!, loser!, battle.DurationInSeconds, battle.Date);

        _context.Battles.Add(battle);
        await Save();

        return battle.Id.Value;
    }
    #endregion

    #endregion

    #region Extra Methods

    public async Task<bool> ExistsBattleIndex(int winnerId, int loserId, DateTime date) =>
        await _context.Battles.AnyAsync(b => b.Winner!.Id == winnerId &&
                                            b.Loser!.Id == loserId &&
                                            b.Date == date);

    #endregion

}
