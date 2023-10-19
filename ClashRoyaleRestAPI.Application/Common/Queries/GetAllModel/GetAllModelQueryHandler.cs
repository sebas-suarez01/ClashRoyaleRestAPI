using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel
{
    public class GetAllModelQueryHandler<TModel, UId> : IQueryHandler<GetAllModelQuery<TModel, UId>, IEnumerable<TModel>>
        where TModel : IEntity<UId>
    {
        private readonly IBaseRepository<TModel, UId> _repository;
        public GetAllModelQueryHandler(IBaseRepository<TModel, UId> repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<TModel>>> Handle(GetAllModelQuery<TModel, UId> request, CancellationToken cancellationToken)
        {
            IEnumerable<TModel> models = await _repository.GetAllAsync();

            return Result.Create(models);
        }
    }
}
