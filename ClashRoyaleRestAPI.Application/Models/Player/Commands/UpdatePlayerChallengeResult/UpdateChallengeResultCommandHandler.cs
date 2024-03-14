using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayerChallengeResult;

internal class UpdateChallengeResultCommandHandler : ICommandHandler<UpdateChallengeResultCommand>
{
    private readonly IPlayerRepository _playerRepository;

    public UpdateChallengeResultCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Result> Handle(UpdateChallengeResultCommand request, CancellationToken cancellationToken = default)
    {
        await _playerRepository.AddPlayerChallengeResult(request.PlayerId,
                                                         request.ChallengeId,
                                                         request.Reward);

        return Result.Success();
    }
}
