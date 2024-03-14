using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.ExceptionHandlers
{
    internal class GetCardByIdQueryExceptionHandler 
        : RequestExceptionHandler<GetModelByIdQuery<CardModel, int>, CardModel, int>
    {
    }
}
