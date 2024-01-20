using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddPlayerClan;

public record AddPlayerClanCommand(Guid ClanId, Guid PlayerId) : ICommand;
