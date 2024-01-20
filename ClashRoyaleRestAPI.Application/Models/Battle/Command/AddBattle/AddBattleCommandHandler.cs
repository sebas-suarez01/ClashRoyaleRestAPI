using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;

internal class AddBattleCommandHandler : ICommandHandler<AddBattleCommand, Guid>
{
    private readonly IBattleRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddBattleCommandHandler(IBattleRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(AddBattleCommand request, CancellationToken cancellationToken = default)
    {
        var winnerId = ValueObjectId.Create<PlayerId>(request.WinnerId);
        var loserId = ValueObjectId.Create<PlayerId>(request.LoserId);

        Guid id = await _repository.Add(request.Battle, winnerId, loserId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return id;

    }
}
