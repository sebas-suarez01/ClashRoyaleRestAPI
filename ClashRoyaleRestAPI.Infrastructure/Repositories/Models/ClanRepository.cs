using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications.Models.Clan;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Common;
using ClashRoyaleRestAPI.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Models;

public class ClanRepository : BaseRepository<ClanModel, ClanId>, IClanRepository
{
    private readonly IPlayerRepository _playerRepository;

    public ClanRepository(ClashRoyaleDbContext context, IPlayerRepository playerRepository) : base(context)
    {
        _playerRepository = playerRepository;
    }

    #region Interface Methods

    #region Queries

    public async Task<PageList<ClanModel>> GetAllAsync(string? name,
                                                    string? region,
                                                    int? minTrophies,
                                                    int? trophiesInWar,
                                                    bool? availables,
                                                    string? sortColumn,
                                                    string? sortOrder,
                                                    int page,
                                                    int pageSize)
    {
        var clans = _context.Clans.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            clans = clans.Where(c => c.Name!.Contains(name));
        }
        if (!string.IsNullOrWhiteSpace(region))
        {
            clans = clans.Where(c => c.Region == region);
        }
        if (minTrophies is not null)
        {
            clans = clans.Where(c => c.MinTrophies <= minTrophies);
        }
        if (trophiesInWar is not null)
        {
            clans = clans.Where(c => c.TrophiesInWar < trophiesInWar);
        }
        if (availables is not null)
        {
            clans = clans.Where(c => c.TypeOpen == availables);
        }

        if (sortOrder?.ToLower() == "desc")
        {
            clans = clans.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            clans = clans.OrderBy(GetSortProperty(sortColumn));
        }

        var paginatedClans = PageList<ClanModel>.Create(clans, page, pageSize);

        await Task.CompletedTask;

        return paginatedClans;
    }

    public async Task<IEnumerable<ClanPlayersModel>> GetPlayers(ClanId clanId)
    {
        var clan = await GetSingleByIdAsync(clanId, new GetClanByIdAsNoTrackingSpecification(clanId));

        await _context.Entry(clan).Collection(c => c.Players).LoadAsync();

        return clan.Players.ToList();
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

    public async Task<ClanId> Add(PlayerId playerId, ClanModel clan)
    {
        await Add(clan);

        var player = await _playerRepository.GetSingleByIdAsync(playerId);

        clan.AddPlayer(player!, RankClan.Leader);

        return clan.Id;
    }

    public async Task AddPlayer(ClanId clanId, PlayerId playerId, RankClan rank = RankClan.Member)
    {
        if (await ExistsClanPlayer(playerId, clanId))
            throw new DuplicationIdException<string>(playerId.ToString(), clanId.ToString());

        var clan = await GetSingleByIdAsync(clanId);

        var player = await _playerRepository.GetSingleByIdAsync(playerId);

        clan.AddPlayer(player, rank);
    }

    public async Task RemovePlayer(ClanId clanId, PlayerId playerId)
    {
        var clan = await GetSingleByIdAsync(clanId, new GetClanByIdSpecification(clanId));

        var clanPlayer = clan.Players.FirstOrDefault(cp=> cp.Id == playerId) 
            ?? throw new IdNotFoundException<string>(playerId.ToString(), clanId.ToString());

        clan.RemovePlayer(clanPlayer.Player!, clanPlayer.Rank);
    }

    public async Task UpdatePlayerRank(ClanId clanId, PlayerId playerId, RankClan rank)
    {
        var playerClan = await _context.ClanPlayers.FindAsync(playerId, clanId)
            ?? throw new IdNotFoundException<string>(playerId.ToString(), clanId.ToString());

        playerClan.UpdateRank(rank);

        _context.Entry(playerClan).State = EntityState.Modified;
    }

    #endregion

    #endregion

    #region Extra Methods

    private async Task<bool> ExistsClanPlayer(PlayerId playerId, ClanId clanId)
    {
        return await _context
            .ClanPlayers
            .AsNoTracking()
            .SingleOrDefaultAsync(cp=> cp.Clan.Id == clanId && cp.Player.Id == playerId) is not null;
    }

    private static Expression<Func<ClanModel, object>> GetSortProperty(string? sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "mintrophies" => clan => clan.MinTrophies,
            "trophiesinwar" => clan => clan.TrophiesInWar,
            "name" => clan => clan.Name!,
            _ => clan => clan.Id
        };
    }
    #endregion

}
