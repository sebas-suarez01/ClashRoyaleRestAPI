using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Battle.Queries.GetBattleByIdWithIncludes;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Battle.ExceptionHandlers;

internal class GetBattleByIdWithIncludesExceptionHandler
    : RequestExceptionHandler<GetBattleByIdWithIncludesQuery, BattleModel, string>
{
}
