using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
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
        await _repository.UpdatePlayerRank(request.ClanId, request.PlayerId, request.Rank);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
