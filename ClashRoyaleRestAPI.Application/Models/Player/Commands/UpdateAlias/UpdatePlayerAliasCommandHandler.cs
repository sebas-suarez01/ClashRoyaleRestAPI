using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdateAlias
{
    public class UpdatePlayerAliasCommandHandler : ICommandHandler<UpdatePlayerAliasCommand>
    {
        private readonly IPlayerRepository _repository;

        public UpdatePlayerAliasCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdatePlayerAliasCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.UpdateAlias(request.Id, request.Alias);
            }
            catch (IdNotFoundException)
            {
                return Result.Failure(ErrorTypes.Models.IdNotFound);
            }

            return Result.Success();
        }
    }
}
