using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Battle.Command.AddBattle
{
    public class AddBattleCommandHandler : ICommandHandler<AddBattleCommand, Guid>
    {
        private readonly IBattleRepository _repository;

        public AddBattleCommandHandler(IBattleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(AddBattleCommand request, CancellationToken cancellationToken)
        {
            Guid id;
            try
            {
                id = await _repository.Add(request.Battle, request.WinnerId, request.LoserId);
            }
            catch (IdNotFoundException<PlayerModel, int>)
            {
                return Result.Failure<Guid>(ErrorTypes.Models.IdNotFound);
            }

            return id;

        }
    }
}
