using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanAvailables;

public record GetClanAvailablesQuery(int Trophies) : IQuery<IEnumerable<ClanModel>>;
