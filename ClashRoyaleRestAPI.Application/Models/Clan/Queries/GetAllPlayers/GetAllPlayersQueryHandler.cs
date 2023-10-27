using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Relationships;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllPlayers
{
    public class GetAllPlayersQueryHandler : IQueryHandler<GetAllPlayersQuery, IEnumerable<ClanPlayersModel>>
    {
        private readonly IClanRepository _repository;

        public GetAllPlayersQueryHandler(IClanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<ClanPlayersModel>>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ClanPlayersModel> players;

            try
            {
                players = await _repository.GetPlayers(request.ClanId);
            }
            catch (IdNotFoundException<int> e)
            {
                return Result.Failure<IEnumerable<ClanPlayersModel>>(ErrorTypes.Models.IdNotFound(e.Message));
            }

            return Result.Create(players);
        }
    }
}
