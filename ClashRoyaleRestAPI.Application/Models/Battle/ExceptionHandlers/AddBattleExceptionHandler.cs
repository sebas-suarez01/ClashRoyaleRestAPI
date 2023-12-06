using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;

namespace ClashRoyaleRestAPI.Application.Models.Battle.ExceptionHandlers;

internal class AddBattleExceptionHandler : RequestExceptionHandler<AddBattleCommand, Guid, int>
{
}
