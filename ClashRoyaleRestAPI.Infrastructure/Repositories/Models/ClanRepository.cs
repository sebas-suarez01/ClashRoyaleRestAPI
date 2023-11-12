using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Clan;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models;

internal class ClanRepository : BaseRepository<ClanModel, int>, IClanRepository
{
    private readonly IPlayerRepository _playerRepository;

    public ClanRepository(ClashRoyaleDbContext context, IPlayerRepository playerRepository) : base(context)
    {
        _playerRepository = playerRepository;
    }

    #region Interface Methods

    #region Queries

    public async Task<IEnumerable<ClanPlayersModel>> GetPlayers(int clanId)
    {
        var clan = await GetSingleByIdAsync(clanId, true);

        return clan.Players.ToList();
    }

    public async Task<ClanModel> GetSingleByIdAsync(int id, bool fullLoad = false)
    {
        var clan = fullLoad ? await ApplySpecification(new GetClanByIdSpecification(id))
                                            .FirstOrDefaultAsync()
                                            ?? throw new IdNotFoundException<int>(id)
                                        : await base.GetSingleByIdAsync(id);

        return clan;
    }

    public async Task<IEnumerable<ClanModel>> GetAllAvailable(int trophies)
    {
        return await ApplySpecification(new GetAllClanAvailableSpecification(trophies)).ToListAsync();
    }

    public async Task<IEnumerable<ClanModel>> GetAllByName(string name)
    {
        return await ApplySpecification(new GetAllClanByNameSpecification(name)).ToListAsync();
    }

    #endregion

    #region Commands

    public async Task<int> Add(int playerId, ClanModel clan)
    {
        await Add(clan);

        var player = await _playerRepository.GetSingleByIdAsync(playerId);

        clan.AddPlayer(player!);

        await Save();

        return clan.Id;
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

        var clanPlayer = await ApplySpecification(new GetClanPlayersByIdSpecification(playerId, clanId))
            .FirstAsync();

        _context.Remove(clanPlayer);

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

    #endregion

    #endregion

    #region Extra Methods

    private async Task<bool> ExistsClanPlayer(int playerId, int clandId)
    {
        return await _context.ClanPlayers.FindAsync(playerId, clandId) is not null;
    }

    #endregion

}
