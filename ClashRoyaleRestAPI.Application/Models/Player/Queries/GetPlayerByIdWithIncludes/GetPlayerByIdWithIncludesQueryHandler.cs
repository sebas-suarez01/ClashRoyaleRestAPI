using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications.Models.Player;
using ClashRoyaleRestAPI.Domain.Models;
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
        PlayerModel player = await _repository.GetSingleByIdAsync(request.Id,
                                                                  new GetPlayerByIdSpecification(request.Id));

        return player;
    }
}
