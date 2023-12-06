using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.Clan;

public class GetAllClanAvailableSpecification : Specification<ClanModel>
{
    public GetAllClanAvailableSpecification(int trophies) : base(c => c.TypeOpen && c.MinTrophies < trophies)
    {
        AsNoTracking = true;
    }
}
