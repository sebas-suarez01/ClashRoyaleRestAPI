﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanByIdFullLoad;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.ExceptionHandlers
{
    internal class GetClanByIdFullLoadExceptionHandler
        : RequestExceptionHandler<GetClanByIdFullLoadQuery, ClanModel, int>
    {
    }
}