﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Relationships;

namespace ClashRoyaleRestAPI.Application.Clan.Queries.GetAllPlayers
{
    public record GetAllPlayersQuery(int ClanId) : IQuery<IEnumerable<ClanPlayersModel>>;
}
