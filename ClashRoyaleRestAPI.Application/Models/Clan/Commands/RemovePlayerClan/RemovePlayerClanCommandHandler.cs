using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.RemovePlayerClan;

internal class RemovePlayerClanCommandHandler : ICommandHandler<RemovePlayerClanCommand>
{
    private readonly IClanRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public RemovePlayerClanCommandHandler(IClanRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemovePlayerClanCommand request, CancellationToken cancellationToken = default)
    {
        var clanId = ValueObjectId.Create<ClanId>(request.ClanId);
        var playerId = ValueObjectId.Create<PlayerId>(request.PlayerId);

        await _repository.RemovePlayer(clanId, playerId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
