using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdateAlias;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers;

internal class UpdatePlayerAliasExceptionHandler
    : RequestExceptionHandler<UpdatePlayerAliasCommand, string>
{
}
