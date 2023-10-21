using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Application.Player.Queries.GetPlayerByIdFullLoad
{
    public record GetPlayerByIdFullLoadQuery(int Id, bool FullLoad) : IQuery<PlayerModel>;
}
