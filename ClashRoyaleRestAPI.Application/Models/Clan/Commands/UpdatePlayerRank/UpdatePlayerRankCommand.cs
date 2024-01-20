using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Enum;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank;

public record UpdatePlayerRankCommand(Guid ClanId, Guid PlayerId, RankClan Rank) : ICommand;
