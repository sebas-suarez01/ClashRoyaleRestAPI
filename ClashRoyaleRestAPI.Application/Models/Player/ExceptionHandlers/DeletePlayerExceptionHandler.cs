using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers;

internal class DeletePlayerExceptionHandler 
    : RequestExceptionHandler<DeleteModelCommand<PlayerModel, PlayerId>, string>
{
}
