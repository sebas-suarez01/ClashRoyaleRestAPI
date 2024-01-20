using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanByIdWithIncludes;

internal class GetClanByIdWithIncludesQueryHandler : IQueryHandler<GetClanByIdWithIncludesQuery, ClanModel>
{
    private readonly IClanRepository _repository;

    public GetClanByIdWithIncludesQueryHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ClanModel>> Handle(GetClanByIdWithIncludesQuery request, CancellationToken cancellationToken)
    {
        var clanId = ClanId.Create(request.Id);

        ClanModel clan = await _repository.GetSingleByIdAsync(clanId,
                                                              new GetClanByIdSpecification(clanId));

        return clan!;
    }
}
