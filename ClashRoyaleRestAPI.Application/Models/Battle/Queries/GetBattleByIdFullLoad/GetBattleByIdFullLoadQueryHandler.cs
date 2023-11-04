using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Queries.GetBattleByIdFullLoad
{
    internal class GetBattleByIdFullLoadQueryHandler : IQueryHandler<GetBattleByIdFullLoadQuery, BattleModel>
    {
        private readonly IBattleRepository _repository;

        public GetBattleByIdFullLoadQueryHandler(IBattleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<BattleModel>> Handle(GetBattleByIdFullLoadQuery request, CancellationToken cancellationToken)
        {
            BattleModel battle;
            try
            {
                battle = await _repository.GetSingleByIdAsync(request.Id, request.FullLoad);
            }
            catch (IdNotFoundException<Guid> e)
            {
                return Result.Failure<BattleModel>(ErrorTypes.Models.IdNotFound(e.Message));
            }

            return battle;
        }
    }
}
