using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Player.Commands.UpdateAlias
{
    public record UpdatePlayerAliasCommand(int Id, string Alias) : ICommand;
}
