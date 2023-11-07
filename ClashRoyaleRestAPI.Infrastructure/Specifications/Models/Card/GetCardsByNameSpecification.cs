using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.Card
{
    internal class GetCardsByNameSpecification : Specification<CardModel>
    {
        public GetCardsByNameSpecification(string name) : base(card => card.Name == name)
        {
        }
    }
}
