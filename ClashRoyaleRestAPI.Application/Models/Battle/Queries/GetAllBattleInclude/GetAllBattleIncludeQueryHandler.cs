using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Queries.GetAllBattleInclude;

internal class GetAllBattleIncludeQueryHandler : IQueryHandler<GetAllModelQuery<BattleModel, BattleId>, PageList<BattleModel>>
{
    private readonly IBattleRepository _repository;

    public GetAllBattleIncludeQueryHandler(IBattleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PageList<BattleModel>>> Handle(GetAllModelQuery<BattleModel, BattleId> request, CancellationToken cancellationToken)
    {
        var battles = await _repository.GetAllAsync(request.SortOrder, request.Page, request.PageSize);

        return Result.Create(battles);
    }
}
