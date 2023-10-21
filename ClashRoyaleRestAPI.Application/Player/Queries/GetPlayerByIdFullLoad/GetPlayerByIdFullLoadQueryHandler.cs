using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Player.Queries.GetPlayerByIdFullLoad
{
    public class GetPlayerByIdFullLoadQueryHandler : IQueryHandler<GetPlayerByIdFullLoadQuery, PlayerModel>
    {
        private readonly IPlayerRepository _repository;

        public GetPlayerByIdFullLoadQueryHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<PlayerModel>> Handle(GetPlayerByIdFullLoadQuery request, CancellationToken cancellationToken)
        {
            var player = await _repository.GetSingleByIdAsync(request.Id, request.FullLoad);

            if (player == null)
                return Result.Failure<PlayerModel>(ErrorTypes.Models.IdNotFound);

            return player;
        }
    }
}
