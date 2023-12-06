using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.ExceptionHandlers;

internal class DeleteWarExceptionHandler :
    RequestExceptionHandler<DeleteModelCommand<WarModel, int>, int>
{
}
