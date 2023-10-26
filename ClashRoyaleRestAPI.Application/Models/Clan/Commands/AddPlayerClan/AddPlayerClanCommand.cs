using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddPlayerClan
{
    public record AddPlayerClanCommand(int ClanId, int PlayerId) : ICommand;
}
