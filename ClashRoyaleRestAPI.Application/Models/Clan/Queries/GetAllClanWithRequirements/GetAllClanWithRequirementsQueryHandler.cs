using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClanWithRequirements;

internal class GetAllClanWithRequirementsQueryHandler : IQueryHandler<GetAllClanWithRequirementsQuery, PageList<ClanModel>>
{
    private readonly IClanRepository _clanRepository;

    public GetAllClanWithRequirementsQueryHandler(IClanRepository clanRepository)
    {
        _clanRepository = clanRepository;
    }

    public async Task<Result<PageList<ClanModel>>> Handle(GetAllClanWithRequirementsQuery request, CancellationToken cancellationToken)
    {
        var results = await _clanRepository.GetAllAsync(request.Name,
                                                        request.Region,
                                                        request.MinTrophies,
                                                        request.TrophiesInWar,
                                                        request.Availables,
                                                        request.SortColumn,
                                                        request.SortOrder,
                                                        request.Page,
                                                        request.PageSize);

        return Result.Create(results);
    }
}
