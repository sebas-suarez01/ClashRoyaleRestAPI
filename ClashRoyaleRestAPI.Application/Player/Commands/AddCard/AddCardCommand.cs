using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Player.Commands.AddCard
{
    public record AddCardCommand(int PlayerId, int CardId) : ICommand;
}
