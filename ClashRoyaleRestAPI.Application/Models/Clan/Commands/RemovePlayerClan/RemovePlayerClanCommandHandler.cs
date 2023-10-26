using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Relationships;
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
            catch (IdNotFoundException)
            {
                return Result.Failure(ErrorTypes.Models.IdNotFound);
            }

            return Result.Success();
        }
    }
}
