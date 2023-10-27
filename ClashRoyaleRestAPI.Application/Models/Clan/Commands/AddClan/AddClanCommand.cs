using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan
{
    public record AddClanCommand(int PlayerId, ClanModel Clan) : ICommand<int>;
}
