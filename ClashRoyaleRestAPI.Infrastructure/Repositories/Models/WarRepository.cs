using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications.Models.War;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models;

internal class WarRepository : BaseRepository<WarModel, int>, IWarRepository
{
    private readonly IClanRepository _clanRepository;
    public WarRepository(ClashRoyaleDbContext context, IClanRepository clanRepository) : base(context)
    {
        _clanRepository = clanRepository;
    }


    #region Interface Methods

    #region Queries

    public async Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date)
    {
        return await ApplySpecification(new GetWarByDateSpecification(date)).ToListAsync();
    }

    #endregion

    #region Commands

    public async Task AddClanToWar(int warId, int clanId, int prize)
    {
        if (await ExistsClanWar(clanId, warId))
            throw new DuplicationIdException(clanId, warId);

        var war = await GetSingleByIdAsync(warId);
        var clan = await _clanRepository.GetSingleByIdAsync(clanId);

        var clanWar = ClanWarsModel.Create(clan, war, prize);

        await _context.ClanWars.AddAsync(clanWar);

        await Save();
    }

    #endregion

    #endregion

    #region Extra Methods

    private async Task<bool> ExistsClanWar(int clanId, int warId)
    {
        return await _context.ClanWars.FindAsync(clanId, warId) is not null;
    }

    #endregion

}
