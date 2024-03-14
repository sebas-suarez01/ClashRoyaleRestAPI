using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Application.Specifications.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Queries.GetBattleByIdWithIncludes;

internal class GetBattleByIdWithIncludesQueryHandler : IQueryHandler<GetBattleByIdWithIncludesQuery, BattleModel>
{
    private readonly IBattleRepository _repository;

    public GetBattleByIdWithIncludesQueryHandler(IBattleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BattleModel>> Handle(GetBattleByIdWithIncludesQuery request, CancellationToken cancellationToken)
    {
        BattleModel battle = await _repository
            .GetSingleByIdAsync(request.Id, new GetBattleByIdSpecification(request.Id));

        return battle;
    }
}
