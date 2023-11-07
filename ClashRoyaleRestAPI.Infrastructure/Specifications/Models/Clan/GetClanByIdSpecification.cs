using ClashRoyaleRestAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Clan
{
    internal class GetClanByIdSpecification : Specification<ClanModel>
    {
        public GetClanByIdSpecification(int id) : base(c => c.Id == id)
        {
            AddInclude(q => q.Include(c => c.Players).ThenInclude(p => p.Player!));
        }
    }
}
