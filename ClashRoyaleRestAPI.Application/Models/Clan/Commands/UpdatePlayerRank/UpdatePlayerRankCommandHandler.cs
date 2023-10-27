using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank
{
    public class UpdatePlayerRankCommandHandler : ICommandHandler<UpdatePlayerRankCommand>
    {
        private readonly IClanRepository _repository;

        public UpdatePlayerRankCommandHandler(IClanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdatePlayerRankCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.UpdatePlayerRank(request.ClanId, request.PlayerId, request.Rank);
            }
            catch (IdNotFoundException<int> e)
            {
                return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
            }

            return Result.Success();
        }
    }
}
