using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;

namespace ClashRoyaleRestAPI.Application.Models.User.Commands.UpdateRole;

public record UpdateRoleCommand(string Id, string Role) : ICommand;
