using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanById;

public class GetClanByIdQueryHandler : IQueryHandler<GetClanByIdQuery, ClanModel>
{
    private readonly IClanRepository _clanRepository;

    public GetClanByIdQueryHandler(IClanRepository clanRepository)
    {
        _clanRepository = clanRepository;
    }

    public async Task<Result<ClanModel>> Handle(GetClanByIdQuery request, CancellationToken cancellationToken)
    {
        return await _clanRepository.GetSingleByIdAsync(request.Id);
    }
}