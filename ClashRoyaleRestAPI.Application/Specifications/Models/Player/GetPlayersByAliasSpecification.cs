using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.Player
{
    public class GetPlayersByAliasSpecification : Specification<PlayerModel>
    {
        public GetPlayersByAliasSpecification(string alias) : base(player => player.Alias == alias)
        {
        }
    }
}
