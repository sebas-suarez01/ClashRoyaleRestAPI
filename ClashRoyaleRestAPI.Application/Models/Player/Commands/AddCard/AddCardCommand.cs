using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddCard;

public record AddCardCommand(PlayerId PlayerId, int CardId) : ICommand;
