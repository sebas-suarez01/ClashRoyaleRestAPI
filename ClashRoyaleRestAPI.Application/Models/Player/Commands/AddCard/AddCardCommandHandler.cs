using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddCard;

internal class AddCardCommandHandler : ICommandHandler<AddCardCommand>
{
    private readonly IPlayerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCardCommandHandler(IPlayerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddCardCommand request, CancellationToken cancellationToken = default)
    {
        var playerId = ValueObjectId.Create<PlayerId>(request.PlayerId);

        await _repository.AddCard(playerId, request.CardId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
