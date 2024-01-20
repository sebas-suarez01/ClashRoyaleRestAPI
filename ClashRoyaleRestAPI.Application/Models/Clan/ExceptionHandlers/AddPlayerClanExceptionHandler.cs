using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddPlayerClan;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers;

internal class AddPlayerClanExceptionHandler : RequestExceptionHandler<AddPlayerClanCommand, string>
{
}
