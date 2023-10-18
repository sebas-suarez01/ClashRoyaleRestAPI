using ClashRoyaleRestAPI.Application.Common.Queries.ExistsModelId;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Card.Queries
{
    public class ExistsCardId : ExistsModelIdQueryHandler<ExistsModelIdQuery<CardModel, int>, CardModel, int>
    {
        public ExistsCardId(ICardRepository repository) : base(repository)
        {
        }
    }
}
