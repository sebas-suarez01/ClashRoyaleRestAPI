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
        var clanId = ClanId.Create(request.ClanId);
        var playerId = PlayerId.Create(request.PlayerId);

        await _repository.RemovePlayer(clanId, playerId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
