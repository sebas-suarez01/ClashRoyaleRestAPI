using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Battle.Queries.GetBattleByIdFullLoad;
using ClashRoyaleRestAPI.Domain.Models.Battle;

namespace ClashRoyaleRestAPI.Application.Models.Battle.ExceptionHandlers
{
    internal class GetBattleByIdFullLoadExceptionHandler
        : RequestExceptionHandler<GetBattleByIdFullLoadQuery, BattleModel, Guid>
    {
    }
}
