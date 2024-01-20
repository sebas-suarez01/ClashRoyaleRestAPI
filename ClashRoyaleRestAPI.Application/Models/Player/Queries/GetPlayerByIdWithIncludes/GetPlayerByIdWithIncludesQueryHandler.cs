using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications.Models.Player;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerByIdWithIncludes;

internal class GetPlayerByIdWithIncludesQueryHandler : IQueryHandler<GetPlayerByIdWithIncludesQuery, PlayerModel>
{
    private readonly IPlayerRepository _repository;

    public GetPlayerByIdWithIncludesQueryHandler(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PlayerModel>> Handle(GetPlayerByIdWithIncludesQuery request, CancellationToken cancellationToken)
    {
        var playerId = ValueObjectId.Create<PlayerId>(request.Id);

        PlayerModel player = await _repository.GetSingleByIdAsync(playerId,
                                                                  new GetPlayerByIdSpecification(playerId));

        return player;
    }
}
