using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.RemovePlayerClan;

public record RemovePlayerClanCommand(ClanId ClanId, PlayerId PlayerId) : ICommand;
