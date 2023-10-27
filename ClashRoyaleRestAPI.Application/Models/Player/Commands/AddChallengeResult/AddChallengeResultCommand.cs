using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddChallengeResult
{
    public record AddChallengeResultCommand(int PlayerId, int ChallengeId, int Reward) : ICommand;
}
