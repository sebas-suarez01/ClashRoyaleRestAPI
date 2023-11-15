using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerWithRequirements
{
    internal class GetAllPlayerWithRequirementsQueryHandler : IQueryHandler<GetAllPlayerWithRequirementsQuery, IEnumerable<PlayerModel>>
    {
        private readonly IPlayerRepository _playerRepository;

        public GetAllPlayerWithRequirementsQueryHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Result<IEnumerable<PlayerModel>>> Handle(GetAllPlayerWithRequirementsQuery request, CancellationToken cancellationToken)
        {
            var results = await _playerRepository.GetAllAsync(request.Name,
                                                              request.Elo,
                                                              request.SortColumn,
                                                              request.SortOrder);
            return Result.Create(results);
        }
    }
}
