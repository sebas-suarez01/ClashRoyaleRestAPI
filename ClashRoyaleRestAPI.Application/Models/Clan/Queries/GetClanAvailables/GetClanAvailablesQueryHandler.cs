using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanAvailables
{
    internal class GetClanAvailablesQueryHandler : IQueryHandler<GetClanAvailablesQuery, IEnumerable<ClanModel>>
    {
        private readonly IClanRepository _repository;

        public GetClanAvailablesQueryHandler(IClanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<ClanModel>>> Handle(GetClanAvailablesQuery request, CancellationToken cancellationToken)
        {
            var clans = await _repository.GetAllAvailable(request.Trophies);

            return Result.Create(clans);
        }
    }
}
