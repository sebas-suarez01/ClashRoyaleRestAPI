using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.Clan;

public class GetClanByIdSpecification : Specification<ClanModel>
{
    public GetClanByIdSpecification(ClanId id) : base(c => c.Id == id)
    {
        AddInclude(q => q.Include(c => c.Players).ThenInclude(p => p.Player!));
    }
}
