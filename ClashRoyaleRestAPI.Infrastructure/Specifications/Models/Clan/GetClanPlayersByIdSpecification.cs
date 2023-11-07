using ClashRoyaleRestAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Clan
{
    internal class GetClanPlayersByIdSpecification : Specification<ClanPlayersModel>
    {
        public GetClanPlayersByIdSpecification(int playerId, int clanId)
            : base(cp => cp.Player!.Id == playerId && cp.Clan!.Id == clanId)
        {
            AddInclude(q => q.Include(c => c.Player!));
            AddInclude(q => q.Include(c => c.Clan!));
        }
    }
}
