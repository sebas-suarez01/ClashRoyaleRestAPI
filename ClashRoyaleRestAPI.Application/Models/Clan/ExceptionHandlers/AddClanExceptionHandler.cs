using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers;

internal class AddClanExceptionHandler : RequestExceptionHandler<AddClanCommand, Guid, string>
{
}
