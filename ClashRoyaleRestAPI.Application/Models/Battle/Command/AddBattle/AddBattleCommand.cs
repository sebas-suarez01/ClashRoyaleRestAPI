using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;

public record AddBattleCommand(BattleModel Battle, Guid WinnerId, Guid LoserId) : ICommand<Guid>;
