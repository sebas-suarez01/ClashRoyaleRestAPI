using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.RemovePlayerClan;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers;

internal class RemovePlayerExceptionHandler : RequestExceptionHandler<RemovePlayerClanCommand, string>
{
}
