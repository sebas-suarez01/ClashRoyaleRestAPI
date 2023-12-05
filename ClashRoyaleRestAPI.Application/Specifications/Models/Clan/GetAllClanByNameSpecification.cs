using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.Clan
{
    public class GetAllClanByNameSpecification : Specification<ClanModel>
    {
        public GetAllClanByNameSpecification(string name) : base(c => c.Name!.Contains(name))
        {
        }
    }
}
