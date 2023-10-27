using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddPlayerClan
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
            catch (IdNotFoundException<int> e)
            {
                return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
            }
            catch (DuplicationIdException e)
            {
                return Result.Failure(ErrorTypes.Models.DuplicateId(e.Message));
            }

            return Result.Success();
        }
    }
}
