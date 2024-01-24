using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddClanWar;

public record AddClanWarCommand(ClanId ClanId, WarId WarId, int Prize) : ICommand;
