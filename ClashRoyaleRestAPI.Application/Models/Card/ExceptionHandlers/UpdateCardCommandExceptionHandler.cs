using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.ExceptionHandlers
{
    internal class UpdateCardCommandExceptionHandler
        : RequestExceptionHandler<UpdateModelCommand<CardModel, int>, int>
    {
    }
}
