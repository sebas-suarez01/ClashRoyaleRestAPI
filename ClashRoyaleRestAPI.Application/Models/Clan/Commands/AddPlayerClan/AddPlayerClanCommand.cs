using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddPlayerClan;

public record AddPlayerClanCommand(ClanId ClanId, PlayerId PlayerId) : ICommand;
