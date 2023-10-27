using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.RemovePlayerClan
{
    public class RemovePlayerClanCommandHandler : ICommandHandler<RemovePlayerClanCommand>
    {
        private readonly IClanRepository _repository;

        public RemovePlayerClanCommandHandler(IClanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemovePlayerClanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.RemovePlayer(request.ClanId, request.PlayerId);
            }
            catch (IdNotFoundException<int> e)
            {
                return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
            }

            return Result.Success();
        }
    }
}
