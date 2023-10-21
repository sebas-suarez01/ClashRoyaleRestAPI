using ClashRoyaleRestAPI.Application.Common.Queries.ExistsModelId;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Card.Queries
{
    public class ExistsCardIdQueryHandler : ExistsModelIdQueryHandler<CardModel, int>
    {
        public ExistsCardIdQueryHandler(ICardRepository repository) : base(repository)
        {
        }
    }
}
