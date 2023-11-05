using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddChallengeResult;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers
{
    internal class AddChallengeResultExceptionHandler
        : RequestExceptionHandler<AddChallengeResultCommand, int>
    {
    }
}
