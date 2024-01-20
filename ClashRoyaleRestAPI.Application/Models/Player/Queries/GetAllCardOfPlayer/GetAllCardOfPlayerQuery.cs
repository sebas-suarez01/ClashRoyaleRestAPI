using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllCardOfPlayer;

public record GetAllCardOfPlayerQuery(Guid Id) : IQuery<IEnumerable<CardModel>>;
