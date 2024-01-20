using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.Clan;

public class GetClanPlayersByIdSpecification : Specification<ClanPlayersModel>
{
    public GetClanPlayersByIdSpecification(PlayerId playerId, ClanId clanId)
        : base(cp => cp.Player!.Id == playerId && cp.Clan!.Id == clanId)
    {
        AddInclude(q => q.Include(c => c.Player!));
        AddInclude(q => q.Include(c => c.Clan!));

        AsNoTracking = true;
    }
}
