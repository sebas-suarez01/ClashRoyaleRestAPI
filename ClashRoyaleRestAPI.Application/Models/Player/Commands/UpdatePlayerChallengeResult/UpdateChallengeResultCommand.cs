using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayerChallengeResult;

public record UpdateChallengeResultCommand(PlayerId PlayerId, ChallengeId ChallengeId, int Reward) : ICommand;
