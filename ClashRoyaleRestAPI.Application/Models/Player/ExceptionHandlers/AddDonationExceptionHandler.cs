using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddDonation;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers;

internal class AddDonationExceptionHandler
    : RequestExceptionHandler<AddDonationCommand, string>
{
}
