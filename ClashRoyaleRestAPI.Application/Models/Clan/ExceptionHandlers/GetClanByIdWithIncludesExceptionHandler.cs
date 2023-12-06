using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanByIdWithIncludes;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers;

internal class GetClanByIdWithIncludesExceptionHandler
    : RequestExceptionHandler<GetClanByIdWithIncludesQuery, ClanModel, int>
{
}
