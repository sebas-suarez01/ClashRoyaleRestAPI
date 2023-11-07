using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Clan
{
    internal class GetAllClanByNameSpecification : Specification<ClanModel>
    {
        public GetAllClanByNameSpecification(string name) : base(c => c.Name!.Contains(name))
        {
        }
    }
}
