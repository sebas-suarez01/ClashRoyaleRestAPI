using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Auth.User;

namespace ClashRoyaleRestAPI.Application.Models.User.ExceptionHandlers
{
    internal class DeleteUserExceptionHandler
        : RequestExceptionHandler<DeleteModelCommand<UserModel, string>, string>
    {
    }
}
