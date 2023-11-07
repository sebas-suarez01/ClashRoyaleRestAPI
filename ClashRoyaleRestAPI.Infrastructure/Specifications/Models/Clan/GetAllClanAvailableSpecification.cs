using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Clan
{
    internal class GetAllClanAvailableSpecification : Specification<ClanModel>
    {
        public GetAllClanAvailableSpecification(int trophies) : base(c => c.TypeOpen && c.MinTrophies < trophies)
        {
        }
    }
}
