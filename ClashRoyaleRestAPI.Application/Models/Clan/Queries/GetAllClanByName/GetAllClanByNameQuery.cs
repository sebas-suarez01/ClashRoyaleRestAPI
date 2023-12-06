using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClanByName;

public record GetAllClanByNameQuery(string Name) : IQuery<IEnumerable<ClanModel>>;
