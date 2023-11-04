using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.Queries.GetCardById
{
    internal class GetCardByIdQueryHandler : GetModelByIdQueryHandler<CardModel, int>
    {
        public GetCardByIdQueryHandler(ICardRepository repository) : base(repository)
        {
        }
    }
}
