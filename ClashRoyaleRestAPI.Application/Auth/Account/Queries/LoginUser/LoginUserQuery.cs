using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Response;

namespace ClashRoyaleRestAPI.Application.Auth.Account.Queries.LoginUser
{
    public record LoginUserQuery(LoginModel LoginModel) : IQuery<LoginResponse>;
}
