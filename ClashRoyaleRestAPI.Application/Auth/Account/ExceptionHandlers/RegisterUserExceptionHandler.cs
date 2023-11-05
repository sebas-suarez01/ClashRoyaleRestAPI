using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Auth.Account.Commands.RegisterUser;

namespace ClashRoyaleRestAPI.Application.Auth.Account.ExceptionHandlers
{
    internal class RegisterUserExceptionHandler 
        : RequestExceptionHandler<RegisterUserCommand, string, string>
    {
    }
}
