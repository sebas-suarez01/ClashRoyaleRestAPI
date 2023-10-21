using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Clan.Commands.AddPlayerClan
{
    public class AddPlayerClanCommandHandler : ICommandHandler<AddPlayerClanCommand>
    {
        private readonly IClanRepository _repository;

        public AddPlayerClanCommandHandler(IClanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(AddPlayerClanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddPlayer(request.ClanId, request.PlayerId);
            }
            catch (IdNotFoundException)
            {
                return Result.Failure(ErrorTypes.Models.IdNotFound);
            }
            catch (DuplicationIdException)
            {
                return Result.Failure(ErrorTypes.Models.DuplicateId);
            }

            return Result.Success();
        }
    }
}
