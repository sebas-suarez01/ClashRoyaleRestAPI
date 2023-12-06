using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerByIdWithIncludes;

public record GetPlayerByIdWithIncludesQuery(int Id) : IQuery<PlayerModel>;
