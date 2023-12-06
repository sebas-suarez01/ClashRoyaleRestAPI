using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank;

internal class UpdatePlayerRankCommandHandler : ICommandHandler<UpdatePlayerRankCommand>
{
    private readonly IClanRepository _repository;

    public UpdatePlayerRankCommandHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdatePlayerRankCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdatePlayerRank(request.ClanId, request.PlayerId, request.Rank);

        return Result.Success();
    }
}
