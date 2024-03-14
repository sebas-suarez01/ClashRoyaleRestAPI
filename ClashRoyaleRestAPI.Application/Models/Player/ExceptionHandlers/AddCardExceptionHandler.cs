using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddCard;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers;

internal class AddCardExceptionHandler : RequestExceptionHandler<AddCardCommand, string>
{
}
