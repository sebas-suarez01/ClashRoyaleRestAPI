using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.DomainEvents.PlayerDomainEvents;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using MediatR;

namespace ClashRoyaleRestAPI.Application.Models.Player.Events;

internal class CardAddedDomainEventHandler : INotificationHandler<CardAddedDomainEvent>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CardAddedDomainEventHandler(IPlayerRepository playerRepository, IUnitOfWork unitOfWork)
    {
        _playerRepository = playerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CardAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        var playerId = ValueObjectId.Create<PlayerId>(notification.PlayerId);

        var player = await _playerRepository.GetSingleByIdAsync(playerId);

        player!.AddCardAmount();

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
