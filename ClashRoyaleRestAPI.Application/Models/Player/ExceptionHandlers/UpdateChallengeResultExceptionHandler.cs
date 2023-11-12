using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayerChallengeResult;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers;

internal class UpdateChallengeResultExceptionHandler
    : RequestExceptionHandler<UpdateChallengeResultCommand, int>
{
}
