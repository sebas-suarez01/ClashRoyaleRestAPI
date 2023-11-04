using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerByAlias
{
    internal class GetAllPlayerByAliasQueryHandler : IQueryHandler<GetAllPlayerByAliasQuery, IEnumerable<PlayerModel>>
    {
        private readonly IPlayerRepository _playerRepository;

        public GetAllPlayerByAliasQueryHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Result<IEnumerable<PlayerModel>>> Handle(GetAllPlayerByAliasQuery request, CancellationToken cancellationToken)
        {
            var players = await _playerRepository.GetPlayersByAliasAsync(request.Alias);

            return Result.Create(players);
        }
    }
}
