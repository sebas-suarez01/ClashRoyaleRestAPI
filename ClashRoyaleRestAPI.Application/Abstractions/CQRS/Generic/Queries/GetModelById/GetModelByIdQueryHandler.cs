using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById
{
    public class GetModelByIdQueryHandler<TModel, UId> : IQueryHandler<GetModelByIdQuery<TModel, UId>, TModel>
        where TModel : IEntity<UId>
    {
        private readonly IBaseRepository<TModel, UId> _repository;
        public GetModelByIdQueryHandler(IBaseRepository<TModel, UId> repository)
        {
            _repository = repository;
        }

        public async Task<Result<TModel>> Handle(GetModelByIdQuery<TModel, UId> request, CancellationToken cancellationToken)
        {
            TModel model = await _repository.GetSingleByIdAsync(request.Id);

            return Result.Success(model);
        }
    }
}
