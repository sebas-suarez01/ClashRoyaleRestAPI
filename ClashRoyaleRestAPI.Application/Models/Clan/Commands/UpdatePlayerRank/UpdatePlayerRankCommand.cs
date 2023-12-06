using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Enum;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank;

public record UpdatePlayerRankCommand(int ClanId, int PlayerId, RankClan Rank) : ICommand;
