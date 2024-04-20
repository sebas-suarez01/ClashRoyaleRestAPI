using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanById;

public record GetClanByIdQuery(ClanId Id) : IQuery<ClanModel>
{
    
}