using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers;

internal class DeletePlayerExceptionHandler : RequestExceptionHandler<DeleteModelCommand<PlayerModel, int>, int>
{
}
