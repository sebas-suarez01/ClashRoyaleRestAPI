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
        var winnerId = PlayerId.Create(request.WinnerId);
        var loserId = PlayerId.Create(request.LoserId);

        Guid id = await _repository.Add(winnerId,
                                        loserId,
                                        request.AmountTrophies,
                                        request.DurationInSeconds,
                                        request.Date);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return id;

    }
}
