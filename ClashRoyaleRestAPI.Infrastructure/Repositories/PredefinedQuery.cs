using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Responses;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories
{
    internal class PredefinedQuery : IPredifinedQueries
    {
        private readonly ClashRoyaleDbContext _context;

        public PredefinedQuery(ClashRoyaleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FirstQueryResponse>> FirstQuery()
        {
            //Consulta 1: Conocer los mejores jugadores que participan en una guerra.
            //Por cada clan que participa en una guerra obtener el jugador con más trofeos.

            var clanWars = _context.ClanWars
                                .Include(cw => cw.Clan);
            var clanPlayer = _context.ClanPlayers
                                .Include(cp => cp.Clan)
                                .Include(cp => cp.Player);

            var joinTables = from cw in _context.ClanWars
                             join cp in _context.ClanPlayers on cw.Clan!.Id equals cp.Clan!.Id
                             join p in _context.Players on cp.Player!.Id equals p.Id
                             select new
                             {
                                 ClanId = cp.Clan!.Id,
                                 PlayerId = p.Id,
                                 PlayerName = p.Alias,
                                 Trophies = p.Elo
                             };

            var result = from r in joinTables
                         group r by r.ClanId into clanGroup
                         select clanGroup.MaxBy(t => t.Trophies);

            return await result
                .Select(r=> new FirstQueryResponse(r.PlayerId, r.PlayerName, r.Trophies))
                .ToListAsync();
        }
    }
}
