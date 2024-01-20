using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanByIdWithIncludes;

public record GetClanByIdWithIncludesQuery(Guid Id) : IQuery<ClanModel>;
