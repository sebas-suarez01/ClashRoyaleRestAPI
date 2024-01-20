using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddClanWar;

public record AddClanWarCommand(Guid ClanId, Guid WarId, int Prize) : ICommand;
