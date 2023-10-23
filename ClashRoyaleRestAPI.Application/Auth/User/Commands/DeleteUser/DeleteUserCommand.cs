using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Auth.User.Commands.DeleteUser
{
    public record DeleteUserCommand(string Id) : ICommand;
}
