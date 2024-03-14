using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Messaging;

namespace ClashRoyaleRestAPI.Application.Auth.Account.Queries.LoginUser
{
    public record LoginUserQuery(LoginModel LoginModel) : IQuery<LoginResponse>;
}
