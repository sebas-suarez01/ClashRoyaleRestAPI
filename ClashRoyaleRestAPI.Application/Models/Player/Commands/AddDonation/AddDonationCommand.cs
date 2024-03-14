using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddDonation;

public record AddDonationCommand(PlayerId PlayerId,
                                 ClanId ClanId,
                                 int CardId,
                                 int Amount,
                                 DateTime Date) : ICommand;
