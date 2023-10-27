using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;

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
            try
            {
                await _playerRepository.AddChallengeResult(request.PlayerId, request.ChallengeId, request.Reward);
            }
            catch (IdNotFoundException<int> e)
            {
                return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
            }
            catch (ChallengeClosedException)
            {
                return Result.Failure(ErrorTypes.Models.ChallengeClosed());
            }

            return Result.Success();
        }
    }
}
