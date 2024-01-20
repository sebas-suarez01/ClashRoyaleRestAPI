using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddDonation
{
    public record AddDonationCommand(Guid PlayerId,
                                     Guid ClanId,
                                     int CardId,
                                     int Amount,
                                     DateTime Date) : ICommand;
}
