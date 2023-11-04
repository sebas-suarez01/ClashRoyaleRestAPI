using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllPlayers
{
    internal class GetAllPlayersQueryHandler : IQueryHandler<GetAllPlayersQuery, IEnumerable<ClanPlayersModel>>
    {
        private readonly IClanRepository _repository;

        public GetAllPlayersQueryHandler(IClanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<ClanPlayersModel>>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ClanPlayersModel> players = await _repository.GetPlayers(request.ClanId);

            return Result.Create(players);
        }
    }
}
