using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.User.ExceptionHandlers;

internal class DeleteUserExceptionHandler
    : RequestExceptionHandler<DeleteModelCommand<UserModel, string>, string>
{
}
