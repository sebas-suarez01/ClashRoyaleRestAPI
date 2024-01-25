using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayerChallenge;

internal class AddPlayerChallengeCommandHandler : ICommandHandler<AddPlayerChallengeCommand>
{
    private readonly IPlayerRepository _playerRepository;

    public AddPlayerChallengeCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Result> Handle(AddPlayerChallengeCommand request, CancellationToken cancellationToken = default)
    {
        await _playerRepository.AddPlayerChallenge(request.PlayerId, request.ChallengeId);

        return Result.Success();
    }
}
