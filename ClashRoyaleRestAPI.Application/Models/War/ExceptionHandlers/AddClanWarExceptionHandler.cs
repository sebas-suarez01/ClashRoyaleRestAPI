using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.War.Commands.AddClanWar;

namespace ClashRoyaleRestAPI.Application.Models.War.ExceptionHandlers;

internal class AddClanWarExceptionHandler :
    RequestExceptionHandler<AddClanWarCommand, string>
{
}
