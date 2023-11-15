using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerWithRequirements;

internal class GetAllPlayerWithRequirementsQueryHandler : IQueryHandler<GetAllPlayerWithRequirementsQuery, PageList<PlayerModel>>
{
    private readonly IPlayerRepository _playerRepository;

    public GetAllPlayerWithRequirementsQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Result<PageList<PlayerModel>>> Handle(GetAllPlayerWithRequirementsQuery request, CancellationToken cancellationToken)
    {
        var results = await _playerRepository.GetAllAsync(request.Name,
                                                          request.Elo,
                                                          request.SortColumn,
                                                          request.SortOrder,
                                                          request.Page,
                                                          request.PageSize);
        return Result.Create(results);
    }
}
