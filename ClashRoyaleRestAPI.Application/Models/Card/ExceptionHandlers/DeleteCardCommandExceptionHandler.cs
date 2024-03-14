using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.ExceptionHandlers
{
    internal class DeleteCardCommandExceptionHandler
        : RequestExceptionHandler<DeleteModelCommand<CardModel, int>, int>
    {
    }
}
