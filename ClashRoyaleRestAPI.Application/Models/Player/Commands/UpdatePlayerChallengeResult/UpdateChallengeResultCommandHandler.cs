using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayerChallengeResult;

internal class UpdateChallengeResultCommandHandler : ICommandHandler<UpdateChallengeResultCommand>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateChallengeResultCommandHandler(IPlayerRepository playerRepository, IUnitOfWork unitOfWork)
    {
        _playerRepository = playerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateChallengeResultCommand request, CancellationToken cancellationToken = default)
    {
        var playerId = ValueObjectId.Create<PlayerId>(request.PlayerId);
        var challengeId = ValueObjectId.Create<ChallengeId>(request.ChallengeId);

        await _playerRepository.AddPlayerChallengeResult(playerId, challengeId, request.Reward);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
