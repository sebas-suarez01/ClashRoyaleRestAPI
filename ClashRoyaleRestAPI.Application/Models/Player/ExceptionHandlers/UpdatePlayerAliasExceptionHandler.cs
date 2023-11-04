using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdateAlias;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers
{
    internal class UpdatePlayerAliasExceptionHandler
        : RequestExceptionHandler<UpdatePlayerAliasCommand, int>
    {
    }
}
