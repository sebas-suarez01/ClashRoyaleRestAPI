using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers;

internal class GetPlayerByIdExceptionHandler
    : RequestExceptionHandler<GetModelByIdQuery<PlayerModel, int>, int>
{
}
