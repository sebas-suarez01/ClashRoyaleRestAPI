using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank;

public record UpdatePlayerRankCommand(ClanId ClanId, PlayerId PlayerId, RankClan Rank) : ICommand;
