using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddDonation
{
    public record AddDonationCommand(int PlayerId, int ClanId, int CardId, int Amount) : ICommand;
}
