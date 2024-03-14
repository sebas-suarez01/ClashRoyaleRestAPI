using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;

public record AddBattleCommand(PlayerId WinnerId,
                               PlayerId LoserId,
                               int AmountTrophies,
                               int DurationInSeconds,
                               DateTime Date) : ICommand<Guid>;
