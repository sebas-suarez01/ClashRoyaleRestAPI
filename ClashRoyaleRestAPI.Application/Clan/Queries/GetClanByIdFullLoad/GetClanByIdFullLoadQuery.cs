﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Clan;

namespace ClashRoyaleRestAPI.Application.Clan.Queries.GetClanByIdFullLoad
{
    public record GetClanByIdFullLoadQuery(int Id, bool FullLoad) : IQuery<ClanModel>;
}
