using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models.Clan;

namespace ClashRoyaleRestAPI.Application.Clan.Commands.AddClan
{
    public record AddClanCommand(int PlayerId, ClanModel Clan) : ICommand<int>;
}
