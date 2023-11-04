using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddChallengeResult;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers
{
    internal class AddChallengeResultExceptionHandler
        : RequestExceptionHandler<AddChallengeResultCommand, int>
    {
    }
}
