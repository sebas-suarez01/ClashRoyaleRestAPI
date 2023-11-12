using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayerChallengeResult;

public record UpdateChallengeResultCommand(int PlayerId, int ChallengeId, int Reward) : ICommand;
