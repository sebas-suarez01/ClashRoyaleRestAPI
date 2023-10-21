using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Clan.Commands.AddPlayerClan
{
    public record AddPlayerClanCommand(int ClanId, int PlayerId) : ICommand;
}
