using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Utils;

namespace ClashRoyaleRestAPI.Application.Auth.Account.Commands.RegisterUser
{
    public record RegisterUserCommand(
        RegisterModel RegisterModel,
        RoleEnum Role = RoleEnum.User
        ) : ICommand<string>;
}
