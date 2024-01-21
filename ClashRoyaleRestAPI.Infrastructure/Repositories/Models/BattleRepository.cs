using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications.Models.Battle;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
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
    public async Task<Guid> Add(PlayerId winnerId,
                                PlayerId loserId,
                                int amountTrophies,
                                int durationInSeconds,
                                DateTime date)
    {
        if (await ExistsBattleIndex(winnerId, winnerId, date))
            throw new DuplicationIndexException(string.Join(",", winnerId, loserId, date));

        var winner = await _playerRepository.GetSingleByIdAsync(winnerId);
        var loser = await _playerRepository.GetSingleByIdAsync(loserId);

        var battle = BattleModel.Create(amountTrophies, winner!, loser!, durationInSeconds, date);

        _context.Battles.Add(battle);

        return battle.Id.Value;
    }
    #endregion

    #endregion

    #region Extra Methods

    public async Task<bool> ExistsBattleIndex(PlayerId winnerId, PlayerId loserId, DateTime date) =>
        await _context.Battles.AnyAsync(b => b.Winner!.Id == winnerId &&
                                            b.Loser!.Id == loserId &&
                                            b.Date == date);

    #endregion

}
