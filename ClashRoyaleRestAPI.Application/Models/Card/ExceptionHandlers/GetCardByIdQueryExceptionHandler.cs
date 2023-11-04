using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.ExceptionHandlers
{
    internal class GetCardByIdQueryExceptionHandler 
        : RequestExceptionHandler<GetModelByIdQuery<CardModel, int>, CardModel, int>
    {
    }
}
