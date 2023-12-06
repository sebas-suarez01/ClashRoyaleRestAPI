using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllPlayers;
using ClashRoyaleRestAPI.Domain.Relationships;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers;

internal class GetAllPlayersExceptionHandler
    : RequestExceptionHandler<GetAllPlayersQuery, IEnumerable<ClanPlayersModel>, int>
{
}
