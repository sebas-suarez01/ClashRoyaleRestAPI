using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.Player;

public sealed class GetPlayerByIdSpecification : Specification<PlayerModel>
{
    public GetPlayerByIdSpecification(PlayerId id)
        : base(player => player.Id == id)
    {
        AddInclude(q => q.Include(player => player.FavoriteCard!));
        AddInclude(q => q.Include(player => player.Cards!).ThenInclude(card => card.Card!));

        AsNoTracking = true;
        IsSplitQuery = true;
    }
}
