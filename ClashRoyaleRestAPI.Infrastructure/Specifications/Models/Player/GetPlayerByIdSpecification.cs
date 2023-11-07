using ClashRoyaleRestAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Player
{
    internal sealed class GetPlayerByIdSpecification : Specification<PlayerModel>
    {
        public GetPlayerByIdSpecification(int id)
            : base(player => player.Id == id)
        {
            AddInclude(q => q.Include(player => player.FavoriteCard!));
            AddInclude(q => q.Include(player => player.Cards!).ThenInclude(card => card.Card!));

        }
    }
}
