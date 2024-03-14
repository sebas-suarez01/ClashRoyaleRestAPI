using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.Queries.GetCardsByName
{
    public record GetCardsByNameQuery(string Name) : IQuery<IEnumerable<CardModel>>;
}
