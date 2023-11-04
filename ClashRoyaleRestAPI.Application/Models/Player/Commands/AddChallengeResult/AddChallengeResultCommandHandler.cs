using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddChallengeResult
{
    internal class AddChallengeResultCommandHandler : ICommandHandler<AddChallengeResultCommand>
    {
        private readonly IPlayerRepository _playerRepository;

        public AddChallengeResultCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Result> Handle(AddChallengeResultCommand request, CancellationToken cancellationToken)
        {
            await _playerRepository.AddChallengeResult(request.PlayerId, request.ChallengeId, request.Reward);

            return Result.Success();
        }
    }
}
