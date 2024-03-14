using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerByIdWithIncludes;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers;

internal class GetPlayerByIdWithIncludesExceptionHandler
    : RequestExceptionHandler<GetPlayerByIdWithIncludesQuery, PlayerModel, string>
{
}
