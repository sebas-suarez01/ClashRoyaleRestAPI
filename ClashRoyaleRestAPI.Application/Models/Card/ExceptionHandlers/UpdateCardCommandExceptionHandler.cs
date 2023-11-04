using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.ExceptionHandlers
{
    internal class UpdateCardCommandExceptionHandler
        : RequestExceptionHandler<UpdateModelCommand<CardModel, int>, int>
    {
    }
}
