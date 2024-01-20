using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayerChallenge;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers;

internal class AddPlayerChallengeExceptionHandler
    : RequestExceptionHandler<AddPlayerChallengeCommand, string>
{
}
