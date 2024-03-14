using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllCardOfPlayer;

public record GetAllCardOfPlayerQuery(PlayerId Id) : IQuery<IEnumerable<CardModel>>;
