using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Queries.GetBattleByIdWithIncludes;

public record GetBattleByIdWithIncludesQuery(BattleId Id) : IQuery<BattleModel>;
