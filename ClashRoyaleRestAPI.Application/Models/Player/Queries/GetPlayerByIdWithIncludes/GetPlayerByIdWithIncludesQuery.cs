using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerByIdWithIncludes;

public record GetPlayerByIdWithIncludesQuery(PlayerId Id) : IQuery<PlayerModel>;
