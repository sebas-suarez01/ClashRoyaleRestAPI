using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.User.Commands.UpdateRole;

public record UpdateRoleCommand(string Id, string Role) : ICommand;
