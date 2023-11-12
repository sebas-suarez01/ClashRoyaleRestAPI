using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.User.ExceptionHandlers
{
    internal class DeleteUserExceptionHandler
        : RequestExceptionHandler<DeleteModelCommand<UserModel, string>, string>
    {
    }
}
