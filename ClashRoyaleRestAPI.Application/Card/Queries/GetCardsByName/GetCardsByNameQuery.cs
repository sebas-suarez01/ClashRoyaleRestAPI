using ClashRoyaleRestAPI.Domain.Models.Card;
using MediatR;

namespace ClashRoyaleRestAPI.Application.Card.Queries.GetCardsByName
{
    public record GetCardsByNameQuery(string Name) : IRequest<IEnumerable<CardModel>>;
}
