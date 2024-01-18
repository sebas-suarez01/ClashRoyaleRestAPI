using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
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
        await _playerRepository.AddPlayerChallengeResult(request.PlayerId, request.ChallengeId, request.Reward);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
