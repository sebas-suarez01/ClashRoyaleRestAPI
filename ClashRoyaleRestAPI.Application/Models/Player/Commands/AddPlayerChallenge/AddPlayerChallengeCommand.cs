using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayerChallenge;

public record AddPlayerChallengeCommand(int PlayerId, int ChallengeId) : ICommand;
