using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanByIdWithIncludes;

public record GetClanByIdWithIncludesQuery(ClanId Id) : IQuery<ClanModel>;
