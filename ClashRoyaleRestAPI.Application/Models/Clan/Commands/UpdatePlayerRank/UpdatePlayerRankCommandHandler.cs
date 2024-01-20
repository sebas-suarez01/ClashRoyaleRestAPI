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
        var clanId = ClanId.Create(request.ClanId);
        var playerId = PlayerId.Create(request.PlayerId);

        await _repository.UpdatePlayerRank(clanId, playerId, request.Rank);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
