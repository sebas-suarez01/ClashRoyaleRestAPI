using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Queries.GetBattleByIdWithIncludes;

public record GetBattleByIdWithIncludesQuery(Guid Id) : IQuery<BattleModel>;
