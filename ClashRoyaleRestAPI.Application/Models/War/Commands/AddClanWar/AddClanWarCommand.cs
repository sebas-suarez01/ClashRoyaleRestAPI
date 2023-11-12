using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddClanWar
{
    public record AddClanWarCommand(int clanId, int warId, int prize) : ICommand;
}
