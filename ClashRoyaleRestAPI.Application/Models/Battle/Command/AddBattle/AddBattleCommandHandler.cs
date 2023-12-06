using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;

internal class AddBattleCommandHandler : ICommandHandler<AddBattleCommand, Guid>
{
    private readonly IBattleRepository _repository;

    public AddBattleCommandHandler(IBattleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(AddBattleCommand request, CancellationToken cancellationToken)
    {
        Guid id = await _repository.Add(request.Battle, request.WinnerId, request.LoserId);

        return id;

    }
}
