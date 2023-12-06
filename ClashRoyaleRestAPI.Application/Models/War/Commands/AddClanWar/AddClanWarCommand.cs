using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddClanWar;

public record AddClanWarCommand(int ClanId, int WarId, int Prize) : ICommand;
