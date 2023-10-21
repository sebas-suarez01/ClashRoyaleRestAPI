using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Battle.Queries.GetAllBattleInclude
{
    public class GetAllBattleIncludeQueryHandler : IQueryHandler<GetAllBattleIncludeQuery, IEnumerable<BattleModel>>
    {
        private readonly IBattleRepository _repository;

        public GetAllBattleIncludeQueryHandler(IBattleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<BattleModel>>> Handle(GetAllBattleIncludeQuery request, CancellationToken cancellationToken)
        {
            var battles = await _repository.GetAllAsync();

            return Result.Create(battles);
        }
    }
}
