using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.ExceptionHandlers
{
    internal class DeleteCardCommandExceptionHandler
        : RequestExceptionHandler<DeleteModelCommand<CardModel, int>, int>
    {
    }
}
