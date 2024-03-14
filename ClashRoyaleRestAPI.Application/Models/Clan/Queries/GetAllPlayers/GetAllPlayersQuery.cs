using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllPlayers;

public record GetAllPlayersQuery(ClanId ClanId) : IQuery<IEnumerable<ClanPlayersModel>>;
