using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdateAlias
{
    internal class UpdatePlayerAliasCommandHandler : ICommandHandler<UpdatePlayerAliasCommand>
    {
        private readonly IPlayerRepository _repository;

        public UpdatePlayerAliasCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdatePlayerAliasCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAlias(request.Id, request.Alias);

            return Result.Success();
        }
    }
}
