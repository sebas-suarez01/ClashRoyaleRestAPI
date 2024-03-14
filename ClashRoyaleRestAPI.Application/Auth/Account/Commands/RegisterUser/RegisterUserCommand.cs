using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Utils;
using ClashRoyaleRestAPI.Application.Messaging;

namespace ClashRoyaleRestAPI.Application.Auth.Account.Commands.RegisterUser
{
    public record RegisterUserCommand(
        RegisterModel RegisterModel,
        RoleEnum Role = RoleEnum.User
        ) : ICommand<string>;
}
