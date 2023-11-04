using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.Queries.GetAllCard
{
    internal class GetAllCardQueryHandler : GetAllModelQueryHandler<CardModel, int>
    {
        public GetAllCardQueryHandler(ICardRepository repository) : base(repository)
        {
        }
    }
}
