using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.RemovePlayerClan;

public record RemovePlayerClanCommand(int ClanId, int PlayerId) : ICommand;
