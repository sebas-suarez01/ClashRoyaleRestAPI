using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank;

internal class UpdatePlayerRankCommandHandler : ICommandHandler<UpdatePlayerRankCommand>
{
    private readonly IClanRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePlayerRankCommandHandler(IClanRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePlayerRankCommand request, CancellationToken cancellationToken = default)
    {
        var clanId = ValueObjectId.Create<ClanId>(request.ClanId);
        var playerId = ValueObjectId.Create<PlayerId>(request.PlayerId);

        await _repository.UpdatePlayerRank(clanId, playerId, request.Rank);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
