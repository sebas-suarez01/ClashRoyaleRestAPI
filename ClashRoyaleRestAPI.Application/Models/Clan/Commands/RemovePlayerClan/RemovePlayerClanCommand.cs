using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.RemovePlayerClan;

public record RemovePlayerClanCommand(Guid ClanId, Guid PlayerId) : ICommand;
