using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.Card;

public class GetCardsByNameSpecification : Specification<CardModel>
{
    public GetCardsByNameSpecification(string name) : base(card => card.Name == name)
    {
    }
}
