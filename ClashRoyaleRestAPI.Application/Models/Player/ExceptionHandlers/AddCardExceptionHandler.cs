using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddCard;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers
{
    internal class AddCardExceptionHandler 
        : RequestExceptionHandler<AddCardCommand, int>
    {
    }
}
