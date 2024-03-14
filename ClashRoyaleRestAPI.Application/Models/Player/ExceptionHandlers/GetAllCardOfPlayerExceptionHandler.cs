using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllCardOfPlayer;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers;

internal class GetAllCardOfPlayerExceptionHandler
    : RequestExceptionHandler<GetAllCardOfPlayerQuery, IEnumerable<CardModel>, string>
{
}
