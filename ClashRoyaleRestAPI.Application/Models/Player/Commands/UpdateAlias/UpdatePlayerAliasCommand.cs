using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdateAlias;

public record UpdatePlayerAliasCommand(Guid Id, string Alias) : ICommand;
