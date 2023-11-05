using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Auth.Account.Queries.LoginUser;
using ClashRoyaleRestAPI.Application.Auth.Response;

namespace ClashRoyaleRestAPI.Application.Auth.Account.ExceptionHandlers
{
    internal class LoginUserExceptionHandler 
        : RequestExceptionHandler<LoginUserQuery, LoginResponse, string>
    {
    }
}
