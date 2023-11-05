using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.ExceptionHandlers
{
    internal class GetCardByIdQueryExceptionHandler 
        : RequestExceptionHandler<GetModelByIdQuery<CardModel, int>, CardModel, int>
    {
    }
}
