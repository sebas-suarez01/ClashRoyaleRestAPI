using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayerChallengeResult;

public record UpdateChallengeResultCommand(Guid PlayerId, Guid ChallengeId, int Reward) : ICommand;
