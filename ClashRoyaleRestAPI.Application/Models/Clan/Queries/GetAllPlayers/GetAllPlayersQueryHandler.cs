using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllPlayers;

internal class GetAllPlayersQueryHandler : IQueryHandler<GetAllPlayersQuery, IEnumerable<ClanPlayersModel>>
{
    private readonly IClanRepository _repository;

    public GetAllPlayersQueryHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<ClanPlayersModel>>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
    {
        var clanId = ValueObjectId.Create<ClanId>(request.ClanId);

        IEnumerable<ClanPlayersModel> players = await _repository.GetPlayers(clanId);

        return Result.Create(players);
    }
}
