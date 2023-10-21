using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Clan.Commands.RemovePlayerClan
{
    public record RemovePlayerClanCommand(int ClanId, int PlayerId) : ICommand;
}
