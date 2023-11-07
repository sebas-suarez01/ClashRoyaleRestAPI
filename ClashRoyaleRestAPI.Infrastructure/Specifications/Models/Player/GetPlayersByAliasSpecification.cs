using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Player
{
    internal class GetPlayersByAliasSpecification : Specification<PlayerModel>
    {
        public GetPlayersByAliasSpecification(string alias) : base(player => player.Alias == alias)
        {
        }
    }
}
