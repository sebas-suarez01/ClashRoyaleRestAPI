using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;

public record AddBattleCommand(Guid WinnerId,
                               Guid LoserId,
                               int AmountTrophies,
                               int DurationInSeconds,
                               DateTime Date) : ICommand<Guid>;
