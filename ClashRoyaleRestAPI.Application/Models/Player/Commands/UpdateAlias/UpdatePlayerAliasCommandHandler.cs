using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdateAlias;

internal class UpdatePlayerAliasCommandHandler : ICommandHandler<UpdatePlayerAliasCommand>
{
    private readonly IPlayerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePlayerAliasCommandHandler(IPlayerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePlayerAliasCommand request, CancellationToken cancellationToken = default)
    {
        var playerId = ValueObjectId.Create<PlayerId>(request.Id);

        await _repository.UpdateAlias(playerId, request.Alias);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
