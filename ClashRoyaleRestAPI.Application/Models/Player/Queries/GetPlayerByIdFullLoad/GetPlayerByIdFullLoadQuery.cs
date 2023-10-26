using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerByIdFullLoad
{
    public record GetPlayerByIdFullLoadQuery(int Id, bool FullLoad) : IQuery<PlayerModel>;
}
