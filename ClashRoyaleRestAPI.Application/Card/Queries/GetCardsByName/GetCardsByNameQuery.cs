using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Card.Queries.GetCardsByName
{
    public record GetCardsByNameQuery(string Name) : IQuery<IEnumerable<CardModel>>;
}
