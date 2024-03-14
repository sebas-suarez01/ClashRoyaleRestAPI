using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayerChallenge;

public record AddPlayerChallengeCommand(PlayerId PlayerId, ChallengeId ChallengeId) : ICommand;
